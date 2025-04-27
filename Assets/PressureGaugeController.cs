using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureGaugeController : MonoBehaviour
{
    public SpriteRenderer GaugeShape;
    public SpriteRenderer Needle;

    public float GaugeMaximum = 100.0f;
    public float GaugeMinimum =   0.0f;
    public float CurrentValue =   0.0f;

    // calculated
    private float GaugeRange = 0.0f;

    public Vector3 RotationMaximum = new Vector3(0.0f, 0.0f,  29.0f);
    public Vector3 RotationMinimum = new Vector3(0.0f, 0.0f, 192.6f);

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
        Vector3 CurrentRotation = Vector3.Slerp(this.RotationMinimum, this.RotationMaximum, this.Percentage());
        this.Needle.transform.localEulerAngles = CurrentRotation;
    }
}
