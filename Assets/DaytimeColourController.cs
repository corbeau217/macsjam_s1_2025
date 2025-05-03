using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DaySection {
    BeforeSunrise,
    AfterSunrise,
    BeforeSunset,
    AfterSunset
}

public class DaytimeColourController : MonoBehaviour
{
    public SpriteRenderer SkySprite;

    public Color Sunrise;
    public Color Noon;
    public Color Sunset;
    public Color Midnight;

    public GameClock clock;

    public float CurrentDayFraction = 0.0f;

    public float SunriseDayFraction = 0.25f;
    public float NoonDayFraction = 0.5f;
    public float SunsetDayFraction = 0.75f;

    public DaySection CurrentDaySegment;

    public float CurrentDaySegmentT = 0.0f;

    public Color UsingColor;

    public void UpdateDaySegment(){
        // prepare day fraction, assuming sunrise if we have no clock
        this.CurrentDayFraction = ((this.clock!=null)? this.clock.GetDayFraction() : this.SunriseDayFraction ) % 1.0f;
        float segmentRange = 0.0f;

        // figure out which segment we're in

        // from midnight to sunrise
        if(this.CurrentDayFraction < this.SunriseDayFraction){
            // set the tone
            this.CurrentDaySegment = DaySection.BeforeSunrise;
            // prepare the range for the T value calculation
            segmentRange = SunriseDayFraction;
            // then calculate it
            CurrentDaySegmentT = (this.CurrentDayFraction) / segmentRange;
        }
        // from sunrise to noon
        else if(this.CurrentDayFraction < this.NoonDayFraction){
            // set the tone
            this.CurrentDaySegment = DaySection.AfterSunrise;
            // prepare the range for the T value calculation
            segmentRange = NoonDayFraction - SunriseDayFraction;
            // then calculate it
            CurrentDaySegmentT = (this.CurrentDayFraction - SunriseDayFraction) / segmentRange;
        }
        // from noon to sunset
        else if(this.CurrentDayFraction < this.SunsetDayFraction){
            // set the tone
            this.CurrentDaySegment = DaySection.BeforeSunset;
            // prepare the range for the T value calculation
            segmentRange = SunsetDayFraction - NoonDayFraction;
            // then calculate it
            CurrentDaySegmentT = (this.CurrentDayFraction - NoonDayFraction) / segmentRange;
        }
        // must be the remaining segment, sunset to midnight
        else {
            // set the tone
            this.CurrentDaySegment = DaySection.AfterSunset;
            // prepare the range for the T value calculation
            segmentRange = 1.0f - SunsetDayFraction;
            // then calculate it
            CurrentDaySegmentT = (this.CurrentDayFraction - SunsetDayFraction) / segmentRange;
        }
    }
    public void DetermineColour(){
        switch (CurrentDaySegment)
        {
            default:
            case DaySection.BeforeSunrise:
                this.UsingColor = Color.Lerp(this.Midnight, this.Sunrise, CurrentDaySegmentT);
                break;
            case DaySection.AfterSunrise:
                this.UsingColor = Color.Lerp(this.Sunrise, this.Noon, CurrentDaySegmentT);
                break;
            case DaySection.BeforeSunset:
                this.UsingColor = Color.Lerp(this.Noon, this.Sunset, CurrentDaySegmentT);
                break;
            case DaySection.AfterSunset:
                this.UsingColor = Color.Lerp(this.Sunset, this.Midnight, CurrentDaySegmentT);
                break;
        }
    }

    public void UpdateColour(){
        // ...
        this.SkySprite.color = new Color( this.UsingColor.r, this.UsingColor.g, this.UsingColor.b, 1.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateDaySegment();
        this.DetermineColour();
        this.UpdateColour();
    }
}
