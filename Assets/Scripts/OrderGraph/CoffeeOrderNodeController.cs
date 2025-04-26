using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeOrderNodeController : MonoBehaviour
{
    public GameObject SelfReference;
    public KeyCode Hotkey;
    public AudioSource SelectSound;


    public void SetActiveStatus( bool newActiveStatus ){
        this.SelfReference.SetActive( newActiveStatus );
    }

    public void Select(){
        this.SetActiveStatus(true);
        this.AttemptSound();
    }
    public void AttemptSound(){
        if(this.SelectSound != null){
            // play with 0 delay
            this.SelectSound.Play( 0 );
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
