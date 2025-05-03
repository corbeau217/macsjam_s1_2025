using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// adding it to the asset menu
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public int totalFunds = 0;
    public int streakHighscore = 0;
    public bool streakHighscoreStrikethrough = false;
}
