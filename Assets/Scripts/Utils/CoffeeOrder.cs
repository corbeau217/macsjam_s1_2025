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
    private const int SIZE_COUNT = 3;
    private const int TYPE_COUNT = 4;
    private const int MILK_COUNT = 4;
    private const int SWEETENER_COUNT = 4;
    // ================================================

    // CONSTRUCTOR
    public CoffeeOrder(int sizeID, int typeID, int milkID, int sweetenerID){
        // use defaults
        this.drinkSize = (DrinkSize)(sizeID%SIZE_COUNT);
        this.drinkType = (DrinkType)(typeID%TYPE_COUNT);

        // modulo the number of items to take care of the spookers

        this.milk = (Milk)(milkID%MILK_COUNT);
        this.sweetener = (Sweetener)(sweetenerID%SWEETENER_COUNT);
    }
    
    // ================================================

    public void randomiseCoffeeOrder(){
        float sizeID = Random.Range(0,SIZE_COUNT);
        float typeID = Random.Range(0,TYPE_COUNT);
        float milkID = Random.Range(0,MILK_COUNT);
        float sweetenerID = Random.Range(0,SWEETENER_COUNT);

        this.drinkSize = (DrinkSize)(sizeID%SIZE_COUNT);
        this.drinkType = (DrinkType)(typeID%TYPE_COUNT);
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

        // debugging spam
        // if(errorCount != 0 ){
        //     Debug.Log( $"meant to be:\n{this.toString()}" );
        //     Debug.Log( $"had:\n{new CoffeeOrder( GroupIDs[0], GroupIDs[1], GroupIDs[2], GroupIDs[3]).toString()}" );
        // }

        return errorCount;
    }

    // ================================================

    private string sizeString(){
        switch (this.drinkSize){
            case DrinkSize.Small: return "Small";
            case DrinkSize.Regular: return "Regular";
            case DrinkSize.Large: return "Large";
            default: return "¿size?";
        }
    }
    private string typeString(){
        switch (this.drinkType){
            case DrinkType.GenericCoffee: return "Generic Coffee";
            case DrinkType.FlatWhite: return "Flat White";
            case DrinkType.Cappuccino: return "Cappuccino";
            case DrinkType.Latte: return "Latte";
            default: return "¿type?";
        }
    }
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
        return this.sizeString()+" "+this.typeString()+" "+this.milkString()+" "+this.sweetenerString();
    }
}

// #######################################################
// #######################################################