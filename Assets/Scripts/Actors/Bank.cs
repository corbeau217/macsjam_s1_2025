using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    // public WholeNumberDisplayer TotalDisplayController;
    public WholeNumberCharDisplayer TotalDisplayController;

    public int Total = 0;

    public void ModifyTotal(int changeInFunds){
        this.Total += changeInFunds;
    }
    public void SetTotal(int newTotal){
        this.Total = newTotal;
    }

    // Start is called before the first frame update
    void Start()
    {
        // ...
    }

    // Update is called once per frame
    void Update()
    {
        this.TotalDisplayController.SetValue( this.Total );
    }
}
