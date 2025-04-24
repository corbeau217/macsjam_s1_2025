using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TargetLocation;


// #######################################################
// #######################################################

public class CoffeeOrder {
    // ================================================
    
    public DrinkSize drinkSize;
    public DrinkType drinkType;
    public Milk milk;
    public Sweetener sweetener;

    // ================================================
    private const int MILK_COUNT = 4;
    private const int SWEETENER_COUNT = 4;
    // ================================================

    // CONSTRUCTOR
    public CoffeeOrder(int milkID, int sweetenerID){
        // use defaults
        this.drinkSize = (DrinkSize)0;
        this.drinkType = (DrinkType)0;

        // modulo the number of items to take care of the spookers

        this.milk = (Milk)(milkID%MILK_COUNT);
        this.sweetener = (Sweetener)(sweetenerID%SWEETENER_COUNT);
    }
    
    // ================================================

    public void randomiseCoffeeOrder(){
        float milkID = Random.Range(0,MILK_COUNT);
        float sweetenerID = Random.Range(0,SWEETENER_COUNT);

        this.milk = (Milk)(milkID%MILK_COUNT);
        this.sweetener = (Sweetener)(sweetenerID%SWEETENER_COUNT);
    }

    // ================================================

    // index error if we got a short array
    //  gives number of errors in the order
    public int GetErrorCountInTransaction( int[] GroupIDs ){
        int sizeID = (int)this.drinkSize;
        int typeID = (int)this.drinkType;
        int milkID = (int)this.milk;
        int sweetenerID = (int)this.sweetener;
        
        // 0 - sizes, 1 - types, 2 - milks, 3 - sweeteners, 4 - payments

        // debugging spam
        // Debug.Log($"SIZE want {GroupIDs[0]} have {sizeID}");
        // Debug.Log($"TYPE want {GroupIDs[1]} have {typeID}");
        // Debug.Log($"MILK want {GroupIDs[2]} have {milkID}");
        // Debug.Log($"SWEETENER want {GroupIDs[3]} have {sweetenerID}");
        
        // say it all
        int errorCount = 0;
        if( GroupIDs[0] != sizeID ){ errorCount++; }
        if( GroupIDs[1] != typeID ){ errorCount++; }
        if( GroupIDs[2] != milkID ){ errorCount++; }
        if( GroupIDs[3] != sweetenerID ){ errorCount++; }

        return errorCount;
    }

    // ================================================

    private string milkString(){
        switch (this.milk){
            case Milk.Dairy: return "Dairy";
            case Milk.Soy: return "Soy";
            case Milk.Almond: return "Almond";
            case Milk.Oat: return "Oat";
            default: return "¿milk?";
        }
    }
    private string sweetenerString(){
        switch (this.sweetener){
            case Sweetener.SugarNone: return "no sugar";
            case Sweetener.SugarHalf: return "1/2 a sugar";
            case Sweetener.SugarFull: return "1 sugar";
            case Sweetener.SugarDouble: return "2 sugars";
            default: return "sweetener?";
        }
    }
    public string toString(){
        return "Order with: "+this.milkString()+" milk, and "+this.sweetenerString();
    }
}

// #######################################################
// #######################################################