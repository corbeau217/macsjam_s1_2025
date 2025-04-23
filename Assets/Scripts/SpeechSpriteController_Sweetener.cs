using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechSpriteController_Sweetener : MonoBehaviour
{
    // TODO have this be used
    public Sprite[] SweetenerSpriteList;
    
    public SpriteRenderer sprite_none;
    public SpriteRenderer sprite_half;
    public SpriteRenderer sprite_full;
    public SpriteRenderer sprite_double;

    public Sweetener usingOption = Sweetener.SugarHalf;

    public void setOption(Sweetener optionToSet){
        this.usingOption = optionToSet;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (this.usingOption)
        {
            default:
            case Sweetener.SugarNone:
                this.sprite_none.enabled   = true;
                this.sprite_half.enabled   = false;
                this.sprite_full.enabled   = false;
                this.sprite_double.enabled = false;
                break;
            case Sweetener.SugarHalf:
                this.sprite_none.enabled   = false;
                this.sprite_half.enabled   = true;
                this.sprite_full.enabled   = false;
                this.sprite_double.enabled = false;
                break;
            case Sweetener.SugarFull:
                this.sprite_none.enabled   = false;
                this.sprite_half.enabled   = false;
                this.sprite_full.enabled   = true;
                this.sprite_double.enabled = false;
                break;
            case Sweetener.SugarDouble:
                this.sprite_none.enabled   = false;
                this.sprite_half.enabled   = false;
                this.sprite_full.enabled   = false;
                this.sprite_double.enabled = true;
                break;
        }
    }
}
