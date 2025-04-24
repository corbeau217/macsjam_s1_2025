using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TargetLocation;




public class CustomerManager : MonoBehaviour
{

    // ========================================================
    // ========================================================


    // ===========================

    // handling order status
    public CoffeeMachineDisplayController CoffeeMachine;

    // customer sprites
    public CustomerObject[] CustomerList;

    public bool currentOrderComplete = false;

    // ===========================

    public CustomerObject currentCustomer;

    public bool GameShouldEnd = false;
    
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
                Debug.Log($"EW THAT WAS YUCK! ({orderErrorCount} mistakes)\n");
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

    // Start is called before the first frame update
    void Start()
    {
        // enforce they start false

        this.GameShouldEnd = false;
        this.currentOrderComplete = false;

        // prep customers

        for (int i = 0; i < this.CustomerList.Length; i++) {
            this.CustomerList[i].initialise();
        }
        this.setCurrentCustomer(this.CustomerList[0]);
    }

    // Update is called once per frame
    void Update()
    {
        // when we dont know yet about the game ending
        if(!this.GameShouldEnd){
            // game state changes
            if(this.CoffeeMachine.IsTooManyErrors()){
                // uhhh game is over
                Debug.Log("RIP you lost!");
                this.GameShouldEnd = true;
            }
            else if(this.CoffeeMachine.IsFinishedOrders()){
                // uhhh game is over
                Debug.Log("You done it!");
                this.GameShouldEnd = true;
            }
        }

        // check for when we need to have our current customer's order completed
        if(this.currentOrderComplete){
            this.currentOrderComplete = false;
            this.currentCustomer.leaveStore();
            this.callNextCustomer();
        }
    }

    // ========================================================
    // ========================================================

}
