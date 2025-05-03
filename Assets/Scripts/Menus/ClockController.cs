using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClockController : MonoBehaviour
{
    public GameClock clock;
    public SevenSegmentController[] DigitControllers;
    public GameObject Divider;

    public bool ShouldBlinkDivider = true;


    // left to right
    public int[] GetExpectedDisplayDigitValues(){
        int[] result = new int[4];
        int hours = this.clock.GetGameHours();
        int minutes = this.clock.GetGameMinutes();
        result[0] = hours/10;
        result[1] = hours%10;
        result[2] = minutes/10;
        result[3] = minutes%10;
        return result;
    }
    public void UpdateClockFace(){
        int[] displayDigits = this.GetExpectedDisplayDigitValues();
        // set each digit
        for (int i = 0; i < this.DigitControllers.Length; i++) {
            this.DigitControllers[i].SetDisplayDigit(displayDigits[i]);
        }
        if(this.ShouldBlinkDivider){
            this.Divider.SetActive( ((int)(Time.time) % 2) == 0 );
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        // ...
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateClockFace();
    }
}
