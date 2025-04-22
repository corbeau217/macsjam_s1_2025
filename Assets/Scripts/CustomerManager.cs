using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TargetLocation;




public class CustomerManager : MonoBehaviour
{

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


    // the current customer number, starts as 0, changes throughout game
    public int currentCustomerID = 0;

    // ===========================

    private const int CUSTOMER_COUNT = 4;

    // ===========================

    /**
     * get CustomerObject or get null
     */
    CustomerObject getCustomer(int customerID){
        switch (customerID)
        {
            case 1:
                return Customer1;
            case 2:
                return Customer2;
            case 3:
                return Customer3;
            case 4:
                return Customer4;
            default:
                return null;
        }
    }

    /**
     * marks the current customer as complete and moves on to next customer
     */
    void completedOrder(){
        CustomerObject current = getCustomer(this.currentCustomerID);
        current.leaveStore();
        this.currentCustomerID = ((this.currentCustomerID+1)%CUSTOMER_COUNT)+1;
    }

    // ===========================


    // ========================================================
    // ========================================================

    // Start is called before the first frame update
    void Start()
    {
        this.Customer1.provideLocations( this.StoreEntrance, this.OrderingLocation, this.StoreExit);
        this.Customer2.provideLocations( this.StoreEntrance, this.OrderingLocation, this.StoreExit);
        this.Customer3.provideLocations( this.StoreEntrance, this.OrderingLocation, this.StoreExit);
        this.Customer4.provideLocations( this.StoreEntrance, this.OrderingLocation, this.StoreExit);
    }

    // Update is called once per frame
    void Update()
    {
        // check if we're the first frame
        if(this.currentCustomerID == 0){
            // very first frame, deal with it

        }
        else {
            // otherwise do each customer
        }
    }
}
