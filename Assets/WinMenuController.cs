using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenuController : MonoBehaviour
{
    public MenuToasterController WinToaster;

    public void Won(){
        this.WinToaster.KeyPressDetected_Override = true;
    }
    public void Reset(){
        this.WinToaster.KeyPressDetected_Override = false;
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
