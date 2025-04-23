using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TargetLocation;




public class CustomerManager : MonoBehaviour
{

    // ========================================================
    // ========================================================


    // ===========================

    // location markers
    public GameObject StoreEntrance;
    public GameObject OrderingLocation;
    public GameObject StoreExit;

    // customer sprites
    public CustomerObject Customer1;
    public CustomerObject Customer2;
    public CustomerObject Customer3;
    public CustomerObject Customer4;

    public bool currentOrderComplete = false;

    // ===========================

    public CustomerObject currentCustomer;


    
    // ===========================

    // ========================================================
    // ========================================================


    // goes to the next customer ID and starts their ordering
    void callNextCustomer(){
        // then start the next order if we can
        this.currentCustomer = this.currentCustomer.customer_behind;
    }

    // ===========================

    // this is the light-weight way for other systems to say the order was completed
    public void notifyOrderComplete( bool isMatching ){
        if(!isMatching){
            // TODO: make them angry
            print("EW THAT WAS YUCK!\n");
        }
        this.currentOrderComplete = true;
    } 

    // ===========================

    public Milk GetCurrentOrderMilk(){ return this.currentCustomer.order.milk; }
    public Sweetener GetCurrentOrderSweetener(){ return this.currentCustomer.order.sweetener; }

    // ========================================================
    // ========================================================

    // Start is called before the first frame update
    void Start()
    {
        this.Customer1.provideLocations( this.StoreEntrance, this.OrderingLocation, this.StoreExit);
        this.Customer2.provideLocations( this.StoreEntrance, this.OrderingLocation, this.StoreExit);
        this.Customer3.provideLocations( this.StoreEntrance, this.OrderingLocation, this.StoreExit);
        this.Customer4.provideLocations( this.StoreEntrance, this.OrderingLocation, this.StoreExit);
        this.currentCustomer = this.Customer1;
        this.Customer1.startOrdering();
        this.Customer2.startOrdering();
        this.Customer3.startOrdering();
        this.Customer4.startOrdering();

    }

    // Update is called once per frame
    void Update()
    {
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
