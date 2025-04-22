
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

    

    // ================================================
}

// #######################################################
// #######################################################