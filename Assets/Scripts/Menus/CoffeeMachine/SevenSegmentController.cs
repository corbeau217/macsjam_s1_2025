using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenSegmentController : MonoBehaviour
{
    public SpriteRenderer[] Segments;
    
    public int CurrentDisplayDigit = 8;
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
    public bool[][] DigitBytes = new bool[][]{
        //    a      b      c      d      e      f      g
        new bool[]{  true,  true,  true,  true,  true,  true, false }, // 0
        new bool[]{ false,  true,  true, false, false, false, false }, // 1
        new bool[]{  true,  true, false,  true,  true, false,  true }, // 2
        new bool[]{  true,  true,  true,  true, false, false,  true }, // 3
        new bool[]{ false,  true,  true, false, false,  true,  true }, // 4
        new bool[]{  true, false,  true,  true, false,  true,  true }, // 5
        new bool[]{  true, false,  true,  true,  true,  true,  true }, // 6
        new bool[]{  true,  true,  true, false, false, false, false }, // 7
        new bool[]{  true,  true,  true,  true,  true,  true,  true }, // 8
        new bool[]{  true,  true,  true,  true, false,  true,  true }  // 9
    };

    public void SetDisplayDigit(int digitIndex){
        this.CurrentDigit = digitIndex;
    }

    public void UpdateSegments(){
        if(this.CurrentDisplayDigit != this.CurrentDigit ){
            for (int i = 0; i < this.Segments.Length; i++){
                // get the bit into the sprite enabled status
                this.Segments[i].enabled = this.DigitBytes[ this.CurrentDigit ][ i ];
            }
            this.CurrentDisplayDigit = this.CurrentDigit;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.SetDisplayDigit( 0 );
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateSegments();
    }
}
