using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static TargetLocation;


public class CustomerManager : MonoBehaviour
{

    // ========================================================
    // ========================================================

    public Sprite[] CustomerSpriteOptions;

    // ===========================

    // handling order status
    public CoffeeMachineDisplayController CoffeeMachine;
    public CoffeeOrderFlowGraph OrderGraph;

    public ForcedMenuToaster winMenu;
    public ForcedMenuToaster lossMenu;

    // customer sprites
    public CustomerObject[] CustomerList;

    public bool currentOrderComplete = false;

    // ===========================

    public GameModeState GameStatus = GameModeState.MainMenu;

    public CustomerObject currentCustomer;

    public float ResetInputDelay = 1.0f;
    public float ResetKeySnoozeTime = 0.0f;

    public bool canMakeOrder = false;

    public float reducedPersonalSpace = 2.3f;
    
    // ===========================

    // ========================================================
    // ========================================================

    void setCurrentCustomer( CustomerObject customerInput ){
        this.currentCustomer = customerInput;
        this.currentCustomer.prepareOrderSpeech();
    }

    // goes to the next customer ID and starts their ordering
    void callNextCustomer(){
        // then start the next order if we can
        this.setCurrentCustomer(this.currentCustomer.customer_behind);
    }

    // ===========================

    // this is the light-weight way for other systems to say the order was completed
    public void notifyTransactionComplete( int orderErrorCount ){
        // not already processed
        if(!this.currentOrderComplete){
            // mark it was completed to stop others trying to do things
            this.currentOrderComplete = true;

            // had errors?
            if(orderErrorCount > 0){
                // log it
                // Debug.Log($"EW THAT WAS YUCK! ({orderErrorCount} mistakes)\n");
                // let the customer complain
                this.currentCustomer.HandleYuckyOrder( orderErrorCount );
            }

            // update the coffee machine about it
            this.CoffeeMachine.ProcessOrderTransaction( orderErrorCount );
        }
    } 

    // ===========================

    public Milk GetCurrentOrderMilk(){ return this.currentCustomer.order.milk; }
    public Sweetener GetCurrentOrderSweetener(){ return this.currentCustomer.order.sweetener; }

    // ========================================================
    // ========================================================

    public void TestForReset(){
        if( Input.GetKey( Hotkeys.RestartGameKey ) ){
            this.GameStatus = GameModeState.Restart;
        }
        else if( Input.GetKey( Hotkeys.ExitGameKey ) ){
            SceneManager.LoadScene("MainMenu");
        }
    }
    
    public void GameEndInputSnooze(){
        this.ResetKeySnoozeTime = this.ResetInputDelay;
    }

    public void GameEndInputSnore(){
        // reduce time left for input
        this.ResetKeySnoozeTime = Mathf.Max(this.ResetKeySnoozeTime - Time.deltaTime, 0.0f);
    }
    public void GameEndingTick(){
        this.GameEndInputSnore();

        // can try to reset game 
        if( this.ResetKeySnoozeTime == 0.0f ){
            this.TestForReset();
        }
    }

    // ========================================================
    // ========================================================

    // Start is called before the first frame update
    void Start()
    {
        // ...
    }

    // Update is called once per frame
    void Update()
    {
        switch (this.GameStatus) {
            default:
                break;
            case GameModeState.MainMenu:
                this.GameState_OnMainMenu();
                break;
            case GameModeState.Initialisation:
                this.GameState_OnInitialisation();
                break;
            case GameModeState.Playing:
                this.GameState_OnPlaying();
                break;
            case GameModeState.Won:
                this.GameState_OnWon();
                break;
            case GameModeState.Lost:
                this.GameState_OnLost();
                break;
            case GameModeState.Restart:
                this.GameState_OnRestart();
                break;
            case GameModeState.Returning:
                this.GameState_OnReturning();
                break;
        }
    }
    public void PreGameEndEvent(){
        this.MassBanishment();
        this.MassPolymorph();
        this.GameEndInputSnooze();
        this.canMakeOrder = false;
        this.OrderGraph.DeactivateFlowGraph();

        this.HuddleTogether();
    }
    // ========================================================
    // ========================================================

    public void GameState_OnMainMenu(){
        this.canMakeOrder = false;
        this.GameStatus = GameModeState.Initialisation; // skip
        // ....
    }
    public void GameState_OnInitialisation(){
        this.canMakeOrder = false;

        // enforce they start false

        this.currentOrderComplete = false;

        // prep customers

        for (int i = 0; i < this.CustomerList.Length; i++) {
            this.CustomerList[i].initialise( this.CustomerSpriteOptions );
        }
        this.setCurrentCustomer(this.CustomerList[0]);

        this.GameStatus = GameModeState.Playing;
    }
    public void GameState_OnPlaying(){
        this.canMakeOrder = true;
        
        // look for game state changes
        if(this.CoffeeMachine.IsTooManyErrors()){
            this.PreGameEndEvent();
            this.lossMenu.SetToasting();
            this.GameStatus = GameModeState.Lost;
        }
        // otherwise got enough orders?
        else if(this.CoffeeMachine.IsFinishedOrders()){
            this.PreGameEndEvent();
            this.winMenu.SetToasting();
            this.GameStatus = GameModeState.Won;
        }
        // otherwise do game moment
        else {
            // check for when we need to have our current customer's order completed
            if(this.currentOrderComplete){
                this.currentOrderComplete = false;
                this.currentCustomer.leaveStore();
                this.callNextCustomer();
            }
        }
    }

    public void GameState_OnWon(){
        this.canMakeOrder = false;
        this.currentCustomer.isMoving = false;
        this.GameEndingTick();
    }

    public void GameState_OnLost(){
        this.canMakeOrder = false;
        // make them keep walking
        this.currentCustomer.leaveStore();
        this.callNextCustomer();

        this.GameEndingTick();
    }

    public void GameState_OnRestart(){
        this.canMakeOrder = false;

        this.CoffeeMachine.ResetMachine();
        this.winMenu.RelaxMenu();
        this.lossMenu.RelaxMenu();

        // undo any order tests
        this.currentOrderComplete = false;

        // prep customers

        for (int i = 0; i < this.CustomerList.Length; i++) {
            this.CustomerList[i].Reincarnate();
        }
        this.setCurrentCustomer(this.CustomerList[0]);

        this.ResetKeySnoozeTime = 0.0f;

        this.GameStatus = GameModeState.Playing;
    }

    public void GameState_OnReturning(){
        this.canMakeOrder = false;

        this.CoffeeMachine.ResetMachine();
        this.winMenu.RelaxMenu();
        this.lossMenu.RelaxMenu();

        // undo any order tests
        this.currentOrderComplete = false;

        this.MassBanishment();

        this.ResetKeySnoozeTime = 0.0f;

        this.GameStatus = GameModeState.MainMenu; // uhhhh idk skip to menu?
    }

    // ========================================================
    // ========================================================

    public void MassBanishment(){
        // shut up, get out.
        for (int i = 0; i < this.CustomerList.Length; i++) {
            this.CustomerList[i].Hush();
            this.CustomerList[i].Banish();
        }
    }
    public void MassPolymorph(){
        // shut up, get out.
        for (int i = 0; i < this.CustomerList.Length; i++) {
            this.CustomerList[i].rerollSprite();
        }
    }
    public void HuddleTogether(){
        // shut up, get out.
        for (int i = 0; i < this.CustomerList.Length; i++) {
            this.CustomerList[i].desiredPersonalSpace = this.reducedPersonalSpace;
        }
    }

}
