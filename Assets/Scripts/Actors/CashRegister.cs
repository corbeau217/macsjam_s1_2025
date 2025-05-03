using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashRegister : MonoBehaviour
{   
    public PlayerData player;
    public PressureGaugeMistakeCounter ErrorDisplay;
    public Prices PricesReference;

    public void ProcessTransaction( int[] orderDetails, int orderErrorCount ){
        this.ErrorDisplay.Set( orderErrorCount );
        if(orderErrorCount == 0){
            int orderValue = this.PricesReference.GetOrderTotal( orderDetails );
            this.player.totalFunds += orderValue;
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
