using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WritingString : MonoBehaviour
{
    public GameObject SelfReference;
    public WritingChar[] CharBlocks;

    public string InitialMessage;
    public string CurrentMessage;
    public char[] CurrentMessageChars;


    public void SetValue(string inputString){
        int trimLength = Mathf.Max( this.CharBlocks.Length, inputString.Length );

        if( trimLength <= 0 ){
            this.CurrentMessage = "";
            this.CurrentMessageChars = new char[0];
        }
        else {
            this.CurrentMessage = inputString.Substring(0, trimLength);
            this.CurrentMessageChars = inputString.ToCharArray();
        }
    }

    public void UpdateChars(){
        for (int i = 0; i < this.CharBlocks.Length && i < this.CurrentMessageChars.Length; i++) {
            this.CharBlocks[i].SetChar( this.CurrentMessageChars[i] );
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.SetValue( this.InitialMessage );
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateChars();
    }
}
