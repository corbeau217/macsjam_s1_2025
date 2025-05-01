using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    public SevenSegmentController[] DigitControllers;
    public GameObject Divider;
    
    public float ClockTime = 0.0f; 
    public float TimeScale = 60.0f;

    public bool ShouldBlinkDivider = true;

    public bool FreezeClock = false;

    public void SetTimeInSeconds( float NewTime ){
        this.ClockTime = NewTime;
    }

    public int GetHours(){ return ((((int)(this.ClockTime * this.TimeScale)) / 60) / 60) % 24; }
    public int GetMinutes(){ return (((int)(this.ClockTime * this.TimeScale)) / 60) % 60; }
    public float GetDayFraction(){ return (((this.ClockTime * this.TimeScale) / 3600.0f) % 24.0f)/24.0f; }

    // left to right
    public int[] GetExpectedDisplayDigitValues(){
        int[] result = new int[4];
        int hours = this.GetHours();
        int minutes = this.GetMinutes();
        result[0] = hours/10;
        result[1] = hours%10;
        result[2] = minutes/10;
        result[3] = minutes%10;
        return result;
    }
    public void Clear(){
        this.ClockTime = 0.0f;
    }
    public void UpdateClockFace(){
        int[] displayDigits = this.GetExpectedDisplayDigitValues();
        // set each digit
        for (int i = 0; i < this.DigitControllers.Length; i++) {
            this.DigitControllers[i].SetDisplayDigit(displayDigits[i]);
        }
        if(this.ShouldBlinkDivider){
            this.Divider.SetActive( ((int)ClockTime % 2) == 0 );
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        // set to 6 am
        this.SetTimeInSeconds((21600.0f)/this.TimeScale);
    }

    // Update is called once per frame
    void Update()
    {
        // update time
        if(!this.FreezeClock){ this.ClockTime += Time.deltaTime; }
        this.UpdateClockFace();
    }
}
