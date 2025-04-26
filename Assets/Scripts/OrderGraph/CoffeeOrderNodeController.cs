using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeOrderNodeController : MonoBehaviour
{
    public GameObject SelfReference;
    public KeyCode Hotkey;
    // public 


    public void SetActiveStatus( bool newActiveStatus ){
        this.SelfReference.SetActive( newActiveStatus );
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
