using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoffeeOrderFlowGraph : MonoBehaviour
{

    // ========================================================
    // ========================================================

    public CoffeeOrderNodeGroup[] NodeGroupList;

    public Player PlayerReference;

    public CoffeeCupController MachineCup;

    public OrderStage CurrentOrderStage;

    public int[] OrderSelectionIDs = {};

    // ========================================================
    // ========================================================

    // time before the next update from keyboard inputs
    public float input_timeout = 0.1f;

    // how much time left on the sleeping
    private float input_sleeping_left = 0.0f;

    // ================================================

    // we got sleepy and need to snooze
    void pass_out(){
        this.input_sleeping_left = this.input_timeout;
    }
    // handles the timeout between inputs
    void snore(){
        // cap it at 0 so we dont get negatives
        this.input_sleeping_left = Mathf.Max(0.0f, input_sleeping_left - Time.deltaTime);
    }

    // ========================================================
    // ========================================================

    public void DeactivateFlowGraph(){
        // clear the selections
        this.OrderSelectionIDs = new int[this.NodeGroupList.Length];
        // hide em
        this.HideAllGroups();
        // and make it startable
        this.CurrentOrderStage = OrderStage.Inactive;
    }
    public void ResetFlowGraph(){
        // clear the selections
        this.OrderSelectionIDs = new int[this.NodeGroupList.Length];
        // hide em
        this.HideAllGroups();
        // but then show the first one
        this.NodeGroupList[0].SetActiveStatus( true );
        this.NodeGroupList[0].SetAllActiveStatus( true );
        // and make it startable
        this.CurrentOrderStage = OrderStage.Sizes;
    }
    public void HideAllGroups(){
        for (int i = 0; i < this.NodeGroupList.Length; i++) {
            this.NodeGroupList[i].SetActiveStatus( false );
        }
    }
    // can index out of bounds if not selected enough node groups
    public CoffeeOrderNodeGroup CurrentOrderNodeGroup(){
        switch (this.CurrentOrderStage) {
            default:
            case OrderStage.Inactive:
                return null;
            case OrderStage.Sizes:
                return this.NodeGroupList[0];
            case OrderStage.Types:
                return this.NodeGroupList[1];
            case OrderStage.Milks:
                return this.NodeGroupList[2];
            case OrderStage.Sweeteners:
                return this.NodeGroupList[3];
            case OrderStage.Payments:
                return this.NodeGroupList[4];
        }
    }
    public void CycleNextStage(){
        switch (this.CurrentOrderStage) {
            default:
            case OrderStage.Inactive:
                this.CurrentOrderStage = OrderStage.Sizes;
                break;
            case OrderStage.Sizes:
                this.CurrentOrderStage = OrderStage.Types;
                break;
            case OrderStage.Types:
                this.CurrentOrderStage = OrderStage.Milks;
                break;
            case OrderStage.Milks:
                this.CurrentOrderStage = OrderStage.Sweeteners;
                break;
            case OrderStage.Sweeteners:
                this.CurrentOrderStage = OrderStage.Payments;
                break;
            case OrderStage.Payments:
                this.CurrentOrderStage = OrderStage.ProcessingPayment;
                break;
            case OrderStage.ProcessingPayment:
                this.CurrentOrderStage = OrderStage.Inactive;
                break;
        }
    }
    public void SelectOption( int SelectionID ){
        int groupIndex = 0;
        switch (this.CurrentOrderStage) {
            default:  // uuhhh what? huh?
                break;
            case OrderStage.Sizes:
                groupIndex = 0;
                this.MachineCup.ShowCup();
                break;
            case OrderStage.Types:
                groupIndex = 1;
                break;
            case OrderStage.Milks:
                groupIndex = 2;
                break;
            case OrderStage.Sweeteners:
                groupIndex = 3;
                break;
            case OrderStage.Payments:
                groupIndex = 4;
                break;
        }

        this.OrderSelectionIDs[groupIndex] = SelectionID;


        // make decision
        CoffeeOrderNodeGroup currentGroup = this.CurrentOrderNodeGroup();
        currentGroup.SelectNode( SelectionID );
        
        this.CycleNextStage();
        if(this.CurrentOrderStage != OrderStage.ProcessingPayment){
            CoffeeOrderNodeGroup NextGroup = this.CurrentOrderNodeGroup();
            NextGroup.SetActiveStatus( true ); // enable it if it isnt
            NextGroup.SetAllActiveStatus( true ); // show all
        }
    }

    // ========================================================
    // ========================================================

    public void ProcessOrder(){
        this.MachineCup.TakeCup();
        // give player the order information
        this.PlayerReference.HandleOrderComplete( this.OrderSelectionIDs );
        // mark it as finished
        this.CycleNextStage();
    }

    // ========================================================
    // ========================================================

    int MilkToNodeID( Milk InputMilk ){
        return (int)InputMilk;
    }
    int SweetenerToNodeID( Sweetener InputSweetener ){
        return (int)InputSweetener;
    }

    // ========================================================
    // ========================================================

    public void HandleInputs(){
        if(this.CurrentOrderStage != OrderStage.Inactive){
            KeyCode[] hotkeyGroupToTest = this.CurrentOrderNodeGroup().GetGroupHotkeys();

            // check that group's hotkeys
            for (int i = 0; i < hotkeyGroupToTest.Length; i++) {
                // did we find one?
                if( Input.GetKey( hotkeyGroupToTest[i] ) ){
                    this.SelectOption( i ); // select it then
                    break; // leave the loop
                }
            }
        }
    }

    // ========================================================
    // ========================================================

    // Start is called before the first frame update
    void Start()
    {
        this.OrderSelectionIDs = new int[this.NodeGroupList.Length];
    }

    // Update is called once per frame
    void Update()
    {

        if(this.CurrentOrderStage == OrderStage.Inactive && this.PlayerReference.CustomerManagerObj.canMakeOrder){
                this.ResetFlowGraph();
        }
        else if(this.CurrentOrderStage == OrderStage.ProcessingPayment){
                this.ProcessOrder();
        }
        else {
            // honk shoo
            this.snore();

            // are we awake yet?
            if(this.input_sleeping_left == 0.0f){
                this.HandleInputs();
            }
        }
    }

    // ========================================================
    // ========================================================
}
