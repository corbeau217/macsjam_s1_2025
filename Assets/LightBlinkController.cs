using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlinkController : MonoBehaviour
{
    public SpriteRenderer SpriteToBlink;

    public float IntervalNearMinimum = 2.0f;
    public float IntervalNearMaximum = 0.1f;
    public float CurrentIntervalT = 0.0f;

    public bool ShouldBlink = false;

    public bool LightEnabledByDefault = false;

    public void Enable(){
        this.ShouldBlink = true;
    }
    public void Disable(){
        this.ShouldBlink = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        // ...
    }

    // Update is called once per frame
    void Update()
    {
        if(this.ShouldBlink){
            float interval = Mathf.Lerp(this.IntervalNearMinimum, this.IntervalNearMaximum, this.CurrentIntervalT);
            this.SpriteToBlink.enabled = (int)(Time.realtimeSinceStartup/interval)%2 == 0;
        }
        else {
            this.SpriteToBlink.enabled = this.LightEnabledByDefault;
        }
    }
}
