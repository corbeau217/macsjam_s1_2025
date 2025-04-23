using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechSpriteController_Milk : MonoBehaviour
{
    // TODO have this be used
    public Sprite[] MilkSpriteList;

    public SpriteRenderer sprite_dairy;
    public SpriteRenderer sprite_soy;
    public SpriteRenderer sprite_almond;
    public SpriteRenderer sprite_oat;

    public Milk usingOption = Milk.Dairy;

    public void setOption(Milk optionToSet){
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
            case Milk.Dairy:
                this.sprite_dairy.enabled  = true;
                this.sprite_soy.enabled    = false;
                this.sprite_almond.enabled = false;
                this.sprite_oat.enabled    = false;
                break;
            case Milk.Soy:
                this.sprite_dairy.enabled  = false;
                this.sprite_soy.enabled    = true;
                this.sprite_almond.enabled = false;
                this.sprite_oat.enabled    = false;
                break;
            case Milk.Almond:
                this.sprite_dairy.enabled  = false;
                this.sprite_soy.enabled    = false;
                this.sprite_almond.enabled = true;
                this.sprite_oat.enabled    = false;
                break;
            case Milk.Oat:
                this.sprite_dairy.enabled  = false;
                this.sprite_soy.enabled    = false;
                this.sprite_almond.enabled = false;
                this.sprite_oat.enabled    = true;
                break;
        }
    }
}
