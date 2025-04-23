
// #######################################################
// #######################################################


// purely for the customer state system
public enum TargetLocation {
    Entry,
    Ordering,
    Exit
}

// #######################################################
// #######################################################

public enum DrinkSize {
    Regular
}
public enum DrinkType {
    GenericCoffee
}

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

public enum SpeechBubbleState {
    // needs to know it exists
    Inactive,
    // exists as a controller, needs an order
    Existing,
    // when we've got everything for toasting
    Sliced,
    // currently visible
    Toasting,
    // hidden now
    Popped,
    // waiting before next toast
    Snoring,
    // done waiting, but needs reseting
    Awoken,
    // when it shouldn't show up anymore
    DiedDead
}

// #######################################################
// #######################################################

public enum OrderStage {
    Inactive,
    Sizes,
    Types,
    Milks,
    Sweeteners,
    Payments,
    ProcessingPayment
}

// #######################################################
// #######################################################