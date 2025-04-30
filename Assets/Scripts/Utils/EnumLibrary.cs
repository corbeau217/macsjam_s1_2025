
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
    Small,
    Regular,
    Large
}
public enum DrinkType {
    GenericCoffee,
    FlatWhite,
    Cappuccino,
    Latte
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

public enum SpeechMode {
    Inactive,
    MutteringEnglish,
    MutteringFrench,
    Ordering
}

// #######################################################
// #######################################################

public enum MenuToastState {
    // start of game
    Initialising,
    // when it's hidden
    Ready,
    // when it's moving to the toast location
    Toasting,
    // when it's retreating to the hiding location
    Relaxing,
}


public enum GameModeState {
    // when loading game
    Initialisation,
    // in game
    Playing,
    // win screen
    Won,
    // losing screen
    Lost,
    // reseting game
    Restart
}

// #######################################################
// #######################################################