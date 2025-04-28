using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachineDisplayController : MonoBehaviour
{
    // public BlipCounter SuccessBlipCounter;
    // public BlipCounter ErrorBlipCounter;
    // public OrderErrorDisplay ErrorDisplay;
    public WholeNumberDisplayer StreakCounter;

    public void HandleBadOrder( int mistakeCount ){
        this.StreakCounter.SetValue( 0 );
    }
    public void HandleGoodOrder(){
        this.StreakCounter.ModifyValue( 1 );
    }


    // should enum our status
    public bool IsTooManyErrors(){
        return false;
    }
    public bool IsFinishedOrders(){
        // made all the orders we wanted
        return false;
    }

    public void ProcessOrderTransaction( int orderErrorCount ){
        if( orderErrorCount == 0 ){
            // this.SuccessBlipCounter.Increase();
            // this.ErrorDisplay.Clear();
            this.HandleGoodOrder();
        }
        else {
            // this.ErrorBlipCounter.Increase();
            // this.ErrorDisplay.Set( orderErrorCount );
            this.HandleBadOrder( orderErrorCount );
        }
    }

    public void ResetMachine(){
        this.StreakCounter.SetValue( 0 );
        // this.SuccessBlipCounter.ResetCounter();
        // this.ErrorBlipCounter.ResetCounter();
        // this.ErrorDisplay.Clear();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.StreakCounter.SetValue( 0 );
        // ...
    }

    // Update is called once per frame
    void Update()
    {
        // ...
    }
}
