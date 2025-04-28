using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashRegister : MonoBehaviour
{   
    public Bank BankReference;
    public OrderErrorDisplay ErrorDisplay;
    public Prices PricesReference;

    public void ProcessTransaction( int[] orderDetails, int orderErrorCount ){
        this.ErrorDisplay.Set( orderErrorCount );
        if(orderErrorCount == 0){
            int orderValue = this.PricesReference.GetOrderTotal( orderDetails );
            this.BankReference.ModifyTotal( orderValue );
        }
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
