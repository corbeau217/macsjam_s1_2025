using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachineDisplayController : MonoBehaviour
{
    public PlayerData player;
    // public BlipCounter SuccessBlipCounter;
    // public BlipCounter ErrorBlipCounter;
    // public PressureGaugeMistakeCounter ErrorDisplay;
    public WholeNumberDisplayer StreakCounter;
    public PressureGaugeController PressureGauge;

    public int MistakesForEmploymentTermination = 100;

    // public int StreakHighScore = 0;

    public void HandleBadOrder( int mistakeCount ){
        // find if we need to update our wall note
        if(this.StreakCounter.CurrentValue > this.player.streakHighscore){
            // undo any strike outs
            this.player.streakHighscoreStrikethrough = false;
            // write our streak on the wall
            this.player.streakHighscore = this.StreakCounter.CurrentValue;
        }
        // reset everything and log the mistake
        this.StreakCounter.SetValue( 0 );
        this.PressureGauge.ModifyValue( mistakeCount );
    }
    public void HandleGoodOrder(){
        this.StreakCounter.ModifyValue( 1 );
        // check if we eclipsed the wall counter, and want to strike it out
        if(this.StreakCounter.CurrentValue > this.player.streakHighscore){ 
            this.player.streakHighscoreStrikethrough = true;
        }
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
        // reset the streak counter
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
