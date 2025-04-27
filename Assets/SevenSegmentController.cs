using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenSegmentController : MonoBehaviour
{
    public SpriteRenderer[] Segments;
    public char DisplayByte = (char)0xff;
    public int CurrentDigit = 0;

    //    aaaaa    
    //   f     b   
    //   f     b   
    //   f     b   
    //    ggggg    
    //   e     c   
    //   e     c   
    //   e     c   
    //    ddddd    
    public char[] DigitBytes = {
        //      -gfedcba
        (char)0b00111111, // 0
        (char)0b00000110, // 1
        (char)0b01011011, // 2
        // TODO finish these
        (char)0b00000000, // 3
        (char)0b00000000, // 4
        (char)0b00000000, // 5
        (char)0b00000000, // 6
        (char)0b00000000, // 7
        (char)0b00000000, // 8
        (char)0b00000000  // 9
    };

    public void SetDisplayDigit(int digitIndex){
        this.CurrentDigit = digitIndex;
    }

    public void UpdateSegments(){
        for (int i = 0; i < this.Segments.Length; i++){
            // get the bit
            char mask = (char)(0x01<<i);
            // when bitwise & finds a nonzero, we enable the sprite
            this.Segments[i].enabled = ( (this.DisplayByte & mask) > 0 );
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.SetDisplayDigit(0);
    }

    // Update is called once per frame
    void Update()
    {
        this.DisplayByte = this.DigitBytes[ this.CurrentDigit ];
        this.UpdateSegments();
    }
}
