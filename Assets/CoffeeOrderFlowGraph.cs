using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrderStage {
    Inactive,
    Sizes,
    Types,
    Milks,
    Sweeteners,
    Payments,
    ProcessingPayment
}

public class CoffeeOrderFlowGraph : MonoBehaviour
{

    // ========================================================
    // ========================================================

    public CoffeeOrderNodeGroup[] NodeGroupList;

    public Player PlayerReference;

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
        // make decision
        this.CurrentOrderNodeGroup().SetActiveNode( SelectionID );
        
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
        // give player the order information
        this.PlayerReference.HandleOrderComplete(this.OrderSelectionIDs);
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
        KeyCode[] hotkeySizes = { Hotkeys.Select_Size_RegularCoffee };
        KeyCode[] hotkeyTypes = { Hotkeys.Select_Type_Generic };
        KeyCode[] hotkeyMilks = { Hotkeys.Select_Milk_Dairy, Hotkeys.Select_Milk_Soy, Hotkeys.Select_Milk_Almond, Hotkeys.Select_Milk_Oat };
        KeyCode[] hotkeySweeteners = { Hotkeys.Select_Sweetener_None, Hotkeys.Select_Sweetener_Half, Hotkeys.Select_Sweetener_Full, Hotkeys.Select_Sweetener_Double };
        KeyCode[] hotkeyPayments = { Hotkeys.Select_Payment_Card };

        KeyCode[] hotkeyGroupToTest = {};

        switch (this.CurrentOrderStage) {
            default: // zzz we dont care
                break;
            case OrderStage.Sizes:
                // -------------------
                hotkeyGroupToTest = hotkeySizes;
                // -------------------
                break;
            case OrderStage.Types:
                // -------------------
                hotkeyGroupToTest = hotkeyTypes;
                // -------------------
                break;
            case OrderStage.Milks:
                // -------------------
                hotkeyGroupToTest = hotkeyMilks;
                // -------------------
                break;
            case OrderStage.Sweeteners:
                // -------------------
                hotkeyGroupToTest = hotkeySweeteners;
                // -------------------
                break;
            case OrderStage.Payments:
                // -------------------
                hotkeyGroupToTest = hotkeyPayments;
                // -------------------
                break;
        }
        // check that group's hotkeys
        for (int i = 0; i < hotkeyGroupToTest.Length; i++) {
            // did we find one?
            if( Input.GetKey( hotkeyGroupToTest[i] ) ){
                this.SelectOption( i ); // select it then
                break; // leave the loop
            }
        }
    }

    // ========================================================
    // ========================================================

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.CurrentOrderStage == OrderStage.Inactive){
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
