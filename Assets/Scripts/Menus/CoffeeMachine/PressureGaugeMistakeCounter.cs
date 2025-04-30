using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureGaugeMistakeCounter : MonoBehaviour
{
    public SevenSegmentController SevenSegment;

    public void Set(int newValue){
        this.SevenSegment.SetDisplayDigit(newValue % 10);
    }
    public void Clear(){
        this.SevenSegment.SetDisplayDigit( 0 );
    }

    // Start is called before the first frame update
    void Start()
    {
        this.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        // ...
    }
}
