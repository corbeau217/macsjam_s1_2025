using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WholeNumberCharDisplayer : MonoBehaviour
{
    public AudioSource IncreaseSound;

    // from lowest value to highest value
    public WritingChar[] DigitControllers;

    public int MaximumDisplayValue = 0;
    public int CurrentValue = 0;
    public int CurrentDisplayValue = 8888;

    public int FirstDigitAscii = 48;

    public int[] GetDigits(int inputValue){
        int[] resultDigits = new int[this.DigitControllers.Length];
        
        int currentDivide = 1;
        for (int i = 0; i < resultDigits.Length; i++) {
            int currentDigit = (inputValue / currentDivide) % 10;
            resultDigits[i] = currentDigit;
            // prepare it for next
            currentDivide = currentDivide * 10;
        }
        return resultDigits;
    }

    public void SetValue(int newValue){
        this.CurrentValue = newValue;
    }
    public void ModifyValue(int inputValue){
        if(this.IncreaseSound!=null && inputValue > 0) { this.IncreaseSound.Play(); }
        this.CurrentValue += inputValue;
    }

    public void UpdateDisplayDigits(){
        // when not the same as what's happening
        if(this.CurrentValue != this.CurrentDisplayValue){
            // get the digits from the clamped value
            int[] digits = this.GetDigits( Mathf.Min( this.CurrentValue, this.MaximumDisplayValue ) );
            // update all
            for (int i = 0; i < this.DigitControllers.Length; i++) {
                this.DigitControllers[i].SetChar( (char)(this.FirstDigitAscii + digits[i]%10) );
            }
            // track the change
            this.CurrentDisplayValue = this.CurrentValue;
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
        this.UpdateDisplayDigits();
    }
}
