using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachineDisplayController : MonoBehaviour
{
    public BlipCounter SuccessBlipCounter;
    public BlipCounter ErrorBlipCounter;

    // should enum our status
    public bool IsTooManyErrors(){
        return this.ErrorBlipCounter.IsMaximum();
    }
    public bool IsFinishedOrders(){
        // made all the orders we wanted
        return this.SuccessBlipCounter.IsMaximum();
    }

    public void ProcessOrderTransaction( int orderErrorCount ){
        if( orderErrorCount == 0 ){
            this.SuccessBlipCounter.Increase();
        }
        else {
            this.ErrorBlipCounter.Increase();
        }
    }

    public void ResetMachine(){
        this.SuccessBlipCounter.ResetCounter();
        this.ErrorBlipCounter.ResetCounter();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
