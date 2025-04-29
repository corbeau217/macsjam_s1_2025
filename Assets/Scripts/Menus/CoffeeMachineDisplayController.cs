using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachineDisplayController : MonoBehaviour
{
    // public BlipCounter SuccessBlipCounter;
    // public BlipCounter ErrorBlipCounter;
    // public OrderErrorDisplay ErrorDisplay;
    public WholeNumberDisplayer StreakCounter;
    public PressureGaugeController PressureGauge;
    public WholeNumberDisplayer WallHighscore;

    public int MistakesForEmploymentTermination = 100;

    public int StreakHighScore = 0;

    public void HandleBadOrder( int mistakeCount ){
        // process the streak data
        this.StreakHighScore = Mathf.Max( this.StreakHighScore, this.StreakCounter.CurrentValue );
        this.WallHighscore.SetValue(this.StreakHighScore);
        // reset everything and log the mistake
        this.StreakCounter.SetValue( 0 );
        this.PressureGauge.ModifyValue( mistakeCount );
    }
    public void HandleGoodOrder(){
        this.StreakCounter.ModifyValue( 1 );
    }


    // should enum our status
    public bool IsTooManyErrors(){
        return this.PressureGauge.IsMaximum();
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
        this.PressureGauge.SetToMinimum();
        // this.SuccessBlipCounter.ResetCounter();
        // this.ErrorBlipCounter.ResetCounter();
        // this.ErrorDisplay.Clear();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.StreakCounter.SetValue( 0 );
        // ...
        this.PressureGauge.ChangeMaximum( MistakesForEmploymentTermination );
    }

    // Update is called once per frame
    void Update()
    {
        // ...
    }
}
