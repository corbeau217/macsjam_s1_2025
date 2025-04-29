using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureGaugeController : MonoBehaviour
{
    public SpriteRenderer GaugeShape;
    public SpriteRenderer Needle;
    public AudioSource IncreaseSound;
    public WholeNumberDisplayer ValueDisplay;
    public LightBlinkController WarningLight;

    public float GaugeMaximum = 100.0f;
    public float GaugeMinimum =   0.0f;
    public float CurrentValue =   0.0f;

    // calculated
    private float GaugeRange = 0.0f;

    public float WarningPercentage = 0.7f;

    public Vector3 RotationMaximum = new Vector3(0.0f, 0.0f, -114.7f);
    public Vector3 RotationMinimum = new Vector3(0.0f, 0.0f, 123.8f);

    public void ChangeMaximum( float newMaximum ){
        this.GaugeMaximum = newMaximum;
        this.GaugeRange = this.GaugeMaximum - this.GaugeMinimum;
    }
    public void ModifyValue( float inputValue ){
        this.CurrentValue += inputValue;
        if(this.IncreaseSound!=null && inputValue > 0) { this.IncreaseSound.Play(); }
    }
    public void SetValue(float NewValue){
        this.CurrentValue = NewValue;
    }
    public void SetToMinimum(){
        this.CurrentValue = this.GaugeMinimum;
    }
    public void SetToMaximum(){
        this.CurrentValue = this.GaugeMaximum;
    }
    public void ClampValue(){
        this.CurrentValue = Mathf.Max(this.GaugeMinimum, Mathf.Min(this.GaugeMaximum, this.CurrentValue));
    }
    public float Percentage(){
        return (this.CurrentValue - this.GaugeMinimum)/this.GaugeRange;
    }

    public bool IsMaximum(){
        return this.CurrentValue == this.GaugeMaximum;
    }
    public Vector3 GetNeedleRotation(){
        return Vector3.Lerp(this.RotationMinimum, this.RotationMaximum, this.Percentage());
    }
    // Start is called before the first frame update
    void Start()
    {
        // ... ye
        this.GaugeRange = this.GaugeMaximum - this.GaugeMinimum;
        this.SetToMinimum();
    }

    // Update is called once per frame
    void Update()
    {
        this.ClampValue();
        Vector3 CurrentRotation = GetNeedleRotation();
        this.Needle.transform.localEulerAngles = CurrentRotation;
        this.ValueDisplay.SetValue( (int)(this.CurrentValue) );

        if(this.CurrentValue >= this.WarningPercentage * this.GaugeMaximum){
            this.WarningLight.Enable();
            this.WarningLight.CurrentIntervalT = this.Percentage();
        }
        else{
            this.WarningLight.Disable();
            this.WarningLight.CurrentIntervalT = 0.0f;
        }
    }
}
