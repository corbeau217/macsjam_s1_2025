using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prices : MonoBehaviour
{
    public int[] SizePrices = new int[0];
    public int[] TypePrices = new int[0];
    public int[] MilkPrices = new int[0];
    public int[] SweetenerPrices = new int[0];

    public int GetPriceForSize( int SizeIndex ){
        return this.SizePrices[SizeIndex];
    }
    public int GetPriceForType( int TypeIndex ){
        return this.TypePrices[TypeIndex];
    }
    public int GetPriceForMilk( int MilkIndex ){
        return this.MilkPrices[MilkIndex];
    }
    public int GetPriceForSweetener( int SweetenerIndex ){
        return this.SweetenerPrices[SweetenerIndex];
    }
    public int GetOrderTotal( int[] orderDetails ){
        return this.GetPriceForSize( orderDetails[0] ) +
                this.GetPriceForType( orderDetails[1] ) +
                this.GetPriceForMilk( orderDetails[2] ) +
                this.GetPriceForSweetener( orderDetails[3] );
    }

    // Start is called before the first frame update
    void Start()
    {
        // ...
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
