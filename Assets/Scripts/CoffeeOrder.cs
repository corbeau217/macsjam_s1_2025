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
    private const int SWEETENER_COUNT = 3;
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
            case Sweetener.SugarHalf: return "1/2 sugar";
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