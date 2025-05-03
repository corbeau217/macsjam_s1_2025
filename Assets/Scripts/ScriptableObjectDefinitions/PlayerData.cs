using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// adding it to the asset menu
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public const int STARTING_FUNDS = 10;

    public int totalFunds = STARTING_FUNDS;
    public int streakHighscore = 0;
    public bool streakHighscoreStrikethrough = false;





    // ================================================
    // ================================================
    public bool IsHighscoreDefault(){ return streakHighscore == 0; }
    public bool IsFundsDefault(){ return totalFunds == STARTING_FUNDS; }
    public bool IsSaveDefault(){
        return IsFundsDefault() && IsHighscoreDefault();
    }

    public void ResetHighscore(){
        streakHighscore = 0;
        streakHighscoreStrikethrough = false;
    }
    public void ResetFunds(){
        totalFunds = STARTING_FUNDS;
    }
    public void ResetSavedData(){
        ResetHighscore();
        ResetFunds();
    }
    // ================================================
    // ================================================
}
