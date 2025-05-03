using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeCupController : MonoBehaviour
{
    // public Sprite[] CupArtworks;
    public RandomSpriteList CupList;
    public SpriteRenderer CupRenderer;
    public bool OverrideShowCup = false;

    public void RandomiseCup(){
        this.CupRenderer.sprite = this.CupList.GetSprite();
    }

    public void ShowCup(){
        this.RandomiseCup();
        this.CupRenderer.enabled = true;
    }

    public void TakeCup(){
        this.CupRenderer.enabled = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        if(OverrideShowCup) { this.ShowCup(); }
    }

    // Update is called once per frame
    void Update()
    {
        // ... 
    }
}
