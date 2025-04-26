using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenuController : MonoBehaviour
{
    public MenuToasterController ForcedToaster;

    public void SetToasting(){
        this.ForcedToaster.KeyPressDetected_Override = true;
    }
    public void RelaxMenu(){
        this.ForcedToaster.KeyPressDetected_Override = false;
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
