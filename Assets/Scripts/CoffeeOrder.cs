using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TargetLocation;

// #######################################################
// #######################################################

public enum Milk {
    Dairy,
    Soy,
    Almond,
    Oat
}

public enum Sweetener {
    SugarNone,
    SugarHalf,
    SugarFull,
    SugarDouble
}

// #######################################################
// #######################################################

public class CoffeeOrder {
    // ================================================
    
    public Milk milk;
    public Sweetener sweetener;

    // ================================================
    private const int MILK_COUNT = 4;
    private const int SWEETENER_COUNT = 4;
    // ================================================

    // CONSTRUCTOR
    public CoffeeOrder(int milkID, int sweetenerID){
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
    public bool MatchWithGroupSelectionIDs( int[] GroupIDs ){
        int milkID = (int)this.milk;
        int sweetenerID = (int)this.sweetener;
        // 0 - sizes, 1 - types, 2 - milks, 3 - sweeteners, 4 - payments
        return (GroupIDs[2] == milkID) && (GroupIDs[3] == sweetenerID);
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