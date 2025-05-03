using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameClock", order = 1)]
public class GameClock : ScriptableObject
{
    public const float StartOfTheDay = 36.0f;
    // real seconds
    public float Realtime = 0.0f;

    public bool FreezeClock = true;


    public int GetGameHours(){
        return (int)(Realtime / 6.0f) % 24;
    }
    public int GetGameMinutes(){
        return (int)(Realtime * 10.0f) % 60;
    }
    public float GetDayFraction(){
        return ((Realtime / 6.0f) % 24.0f)/24.0f;
    }


    public void Reset(){
        this.Realtime = 0.0f;
    }

    public void tick(){
        this.Realtime += Time.deltaTime;
    }

    public void StartTheDay(){
        this.Realtime = StartOfTheDay;
        
    }
}
