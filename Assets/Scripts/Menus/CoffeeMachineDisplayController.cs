using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachineDisplayController : MonoBehaviour
{
    public BlipCounter SuccessBlipCounter;
    public BlipCounter ErrorBlipCounter;
    // public OrderErrorDisplay ErrorDisplay;

    // should enum our status
    public bool IsTooManyErrors(){
        return false;
    }
    public bool IsFinishedOrders(){
        // made all the orders we wanted
        return this.SuccessBlipCounter.IsMaximum();
    }

    public void ProcessOrderTransaction( int orderErrorCount ){
        if( orderErrorCount == 0 ){
            this.SuccessBlipCounter.Increase();
            // this.ErrorDisplay.Clear();
        }
        // else {
        //     this.ErrorBlipCounter.Increase();
        //     // this.ErrorDisplay.Set( orderErrorCount );
        // }
    }

    public void ResetMachine(){
        this.SuccessBlipCounter.ResetCounter();
        this.ErrorBlipCounter.ResetCounter();
            // this.ErrorDisplay.Clear();
    }

    // Start is called before the first frame update
    void Start()
    {
        // ...
    }

    // Update is called once per frame
    void Update()
    {
        // ...
    }
}
