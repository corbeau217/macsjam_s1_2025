using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public PlayerData player;

    public SpriteRenderer ResetHighscoreStrikethrough;
    public KeyCode ResetHighscoreHotkey = KeyCode.Alpha8;
    private bool canResetHighscore = true;

    public SpriteRenderer ResetFundsStrikethrough;
    public KeyCode ResetPlayerFundsHotkey = KeyCode.Alpha9;
    private bool canResetFunds = true;
    
    public SpriteRenderer ResetSaveDataStrikethrough;
    public KeyCode ResetSavedDataHotkey = KeyCode.Alpha0;
    private bool canResetSaveData = true;



    // Start is called before the first frame update
    void Start()
    {
        this.canResetHighscore = !this.player.IsHighscoreDefault();
        this.canResetFunds = !this.player.IsFundsDefault();
        this.canResetSaveData = !this.player.IsSaveDefault();
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateOptions();
        this.UpdateStrikethroughs();
        this.HandleInput();
    }
    public void UpdateOptions(){
        if(!(canResetHighscore || canResetFunds)){
            canResetSaveData = false;
        }
    }
    public void UpdateStrikethroughs(){
        if(ResetHighscoreStrikethrough!=null){ ResetHighscoreStrikethrough.enabled = !canResetHighscore; }
        if(ResetFundsStrikethrough!=null){ ResetFundsStrikethrough.enabled = !canResetFunds; }
        if(ResetSaveDataStrikethrough!=null){ ResetSaveDataStrikethrough.enabled = !canResetSaveData; }
    }
    public void HandleInput(){
        if(canResetHighscore && Input.GetKey(this.ResetHighscoreHotkey)){
            this.player.ResetHighscore();
            canResetHighscore = false;
        }
        else if(canResetFunds && Input.GetKey(this.ResetPlayerFundsHotkey)){
            this.player.ResetFunds();
            canResetFunds = false;
        }
        else if(canResetSaveData &&  Input.GetKey(this.ResetSavedDataHotkey)){
            this.player.ResetSavedData();
            canResetHighscore = false;
            canResetFunds = false;
            canResetSaveData = false;
        }
    }
}
