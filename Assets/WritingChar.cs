using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WritingChar : MonoBehaviour
{
    // fetched at the start
    public SpriteRenderer spriteRenderer;

    // 33 to 126 on the ascii table
    public Sprite[] CharSprites;
    public Sprite NullSprite;
    public Sprite ErrorSprite;

    public int AsciiRangeFirst = 33;
    public int AsciiRangeLast = 126;

    public char CurrentValue = (char)0;

    public Sprite GetSprite(char inputChar){
        int charIndex = (int)inputChar;

        // test not in range for our symbols
        if(charIndex != 0 && (charIndex < this.AsciiRangeFirst || charIndex > this.AsciiRangeLast)){
            return this.ErrorSprite;
        }
        else if(charIndex == 0){
            return this.NullSprite;
        }
        // otherwise, safely in range
        else {
            return this.CharSprites[charIndex - AsciiRangeFirst];
        }
    }

    public void SetChar(char inputChar){
        this.CurrentValue = inputChar;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // ...
        this.spriteRenderer.sprite = this.GetSprite( this.CurrentValue );
    }
}
