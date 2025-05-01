using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeCupController : MonoBehaviour
{
    public Sprite[] CupArtworks;
    public SpriteRenderer CupRenderer;
    public bool OverrideShowCup = false;

    public void RandomiseCup(){
        int selectionIndex = Random.Range(0, this.CupArtworks.Length);
        this.CupRenderer.sprite = this.CupArtworks[selectionIndex];
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
        // ...
    }

    // Update is called once per frame
    void Update()
    {
        // ...
    }
}
