using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeechController : MonoBehaviour
{
    public GameObject SelfReference;

    // _____________
    // sprite group \\
    // ==========================================

    public GameObject OrderingSpeechBubble;
    public GameObject MutteringSpeechBubble;
    public AudioSource OrderingSound;
    public AudioSource MutteringSound;

    // ______________
    // sprite layers \\
    // ==========================================

    public SpriteRenderer SizeElement;
    public SpriteRenderer TypeElement;
    public SpriteRenderer MilkElement;
    public SpriteRenderer SweetenerElement;

    public SpriteRenderer MutteringElement;

    // ____________________
    // sprite option lists \\
    // ==========================================

    public Sprite[] SizeSpriteList;
    public Sprite[] TypeSpriteList;
    public Sprite[] MilkSpriteList;
    public Sprite[] SweetenerSpriteList;

    public Sprite[] MutteringEnglishSpriteList;
    public Sprite[] MutteringFrenchSpriteList;

    // _________________
    // default options \\
    // ==========================================

    public Sprite PlaceHolderSpeechSprite;

    // _________________
    // state variables \\
    // ==========================================

    public SpeechBubbleState BubbleStatus = SpeechBubbleState.Inactive;
    
    public SpeechMode SpeechStatus = SpeechMode.Inactive;

    // when we want graceful exiting a bubble loop
    public bool Stabbed = false;

    // _________________________
    // language based variables \\
    // ==========================================

    public int LANGUAGE_COUNT = 2;

    // ___________________
    // toasting variables \\
    // ==========================================

    public float BubbleToasting_TimeMinimum =  3.0f;
    public float BubbleToasting_TimeMaximum = 6.0f;

    public float BubbleToasting_TimeLeft = 0.0f;

    public float BubbleMovementBaseSpeed = 0.3f;
    public float BubbleMovementSpeed = 0.3f;
    public float BubbleMovementSpeedRange = 0.3f;

    // __________________
    // snoring variables \\
    // ==========================================

    public float BubbleSnoring_TimeMinimum =  5.0f;
    public float BubbleSnoring_TimeMaximum = 15.0f;

    public float BubbleSnoring_TimeLeft = 0.0f;

    public CoffeeOrder NewBubbleOrder;

    // desire to loop toasting
    public bool ToastLooping = false;

    // ____________________
    // activate/deactivate \\
    // ==========================================

    public void AttemptMutteringSound(){
        if(this.MutteringSound != null){
            this.MutteringSound.Play();
        }
    }
    public void AttemptOrderingSound(){
        if(this.OrderingSound != null){
            this.OrderingSound.Play();
        }
    }

    public void SetLooping( bool isLooping ){
        this.ToastLooping = isLooping;
    }
    public void SetBubbleActivity( SpeechMode status ){
        switch (status) {
            default:
            case SpeechMode.Inactive:
                this.OrderingSpeechBubble.SetActive( false );
                this.MutteringSpeechBubble.SetActive( false );
                break;
            case SpeechMode.MutteringEnglish:
            case SpeechMode.MutteringFrench:
                this.OrderingSpeechBubble.SetActive( false );
                this.MutteringSpeechBubble.SetActive( true );
                this.AttemptMutteringSound();
                break;
            case SpeechMode.Ordering:
                this.OrderingSpeechBubble.SetActive( true );
                this.MutteringSpeechBubble.SetActive( false );
                this.AttemptOrderingSound();
                break;
        }
    }
    public void BubbleMoveUpdate(){
        Vector3 movementVector = new Vector3(0.0f, this.BubbleMovementSpeed * Time.deltaTime, 0.0f);
        switch ( this.SpeechStatus ) {
            default:
            case SpeechMode.Inactive:
                break;
            case SpeechMode.MutteringEnglish:
            case SpeechMode.MutteringFrench:
                // ...
                this.MutteringSpeechBubble.transform.position = this.MutteringSpeechBubble.transform.position + movementVector;
                break;
            case SpeechMode.Ordering:
                // ...
                this.OrderingSpeechBubble.transform.position = this.OrderingSpeechBubble.transform.position + movementVector;
                break;
        }
    }
    public void ResetBubblePosition(){
        this.MutteringSpeechBubble.transform.position = this.SelfReference.transform.position;
        this.OrderingSpeechBubble.transform.position = this.SelfReference.transform.position;

    }

    // _______________________
    // state handle functions \\
    // ==========================================

    public void BubbleState_OnInactive(){
        this.BubbleToasting_TimeLeft = 0.0f;
        this.BubbleSnoring_TimeLeft = 0.0f;
        this.Stabbed = false;
        
        // remove any speech statuses
        this.SpeechStatus = SpeechMode.Inactive;

        // ready for slurping up new order
        this.BubbleStatus = SpeechBubbleState.Existing;
    }

    public void BubbleState_OnExisting(){
        // ready for slurping up new order
        if(this.NewBubbleOrder != null ){
            this.SpeechStatus = SpeechMode.Ordering;
            this.SliceOrder();
        }
        else {
            this.RollMutteringLanguage();
            this.BubbleStatus = SpeechBubbleState.Sliced;
        }
    }

    public void BubbleState_OnSliced(){
        // check for muttering and prep
        switch (this.SpeechStatus) {
            // not muttering
            default:
                break;
            // muttering rolling
            case SpeechMode.MutteringEnglish:
            case SpeechMode.MutteringFrench:
                this.ReSliceMuttering();
                break;
        }

        // now deal with the toast looping
        if(this.ToastLooping){
            // show the whole collection based on status
            this.SetBubbleActivity( this.SpeechStatus );
            // set us up to toast
            this.BubbleToasting_TimeLeft = Random.Range( this.BubbleToasting_TimeMinimum, this.BubbleToasting_TimeMaximum );
            // BZZZRRRRTTT
            this.BubbleStatus = SpeechBubbleState.Toasting;
            this.BubbleMovementSpeed = Random.Range( this.BubbleMovementBaseSpeed-(BubbleMovementSpeedRange/2.0f), this.BubbleMovementBaseSpeed+(BubbleMovementSpeedRange/2.0f) );
        }
    }

    public void BubbleState_OnToasting(){
        // lower bound as 0.0f
        this.BubbleToasting_TimeLeft = Mathf.Max(this.BubbleToasting_TimeLeft - Time.deltaTime, 0.0f);
        this.BubbleMoveUpdate();
        // check we should awake
        if(this.BubbleToasting_TimeLeft == 0.0f){
            // next update will catch this and update it
            this.BubbleStatus = SpeechBubbleState.Popped;
            this.ResetBubblePosition();
        }
    }

    public void BubbleState_OnPopped(){
        // hide the collections
        this.SetBubbleActivity( SpeechMode.Inactive );
        // make us sleepy
        this.BubbleSnoring_TimeLeft = Random.Range( this.BubbleSnoring_TimeMinimum, this.BubbleSnoring_TimeMaximum );
        // honk shoo zzz
        this.BubbleStatus = SpeechBubbleState.Snoring;
    }

    public void BubbleState_OnSnoring(){
        // lower bound as 0.0f
        this.BubbleSnoring_TimeLeft = Mathf.Max(this.BubbleSnoring_TimeLeft - Time.deltaTime, 0.0f);
        // check we should awake
        if(this.BubbleSnoring_TimeLeft == 0.0f){
            // next update will catch this and update it
            this.BubbleStatus = SpeechBubbleState.Awoken;
        }
    }
    
    public void BubbleState_OnAwoken(){
        // when we're dying after a toast
        if(this.Stabbed){
            this.BubbleStatus = SpeechBubbleState.DiedDead;
        }
        else {
            // just move along ready for toasting
            this.BubbleStatus = SpeechBubbleState.Sliced;
        }
    }

    public void BubbleState_OnDiedDead(){
        // hide both collections
        this.SetBubbleActivity( SpeechMode.Inactive );

        // remove muttering chances
        this.SpeechStatus = SpeechMode.Inactive;

        // make it not active
        this.BubbleStatus = SpeechBubbleState.Inactive;
    }

    // _____________________
    // mutttering functions \\
    // ==========================================

    public void RollMutteringLanguage(){
        // choose language
        int languageIndex = Random.Range(0,this.LANGUAGE_COUNT);
        switch (languageIndex)
        {
            case 0:
                this.SpeechStatus = SpeechMode.MutteringEnglish;
                break;
            default:
            case 1:
                this.SpeechStatus = SpeechMode.MutteringFrench;
                break;
        }
        // let the toasting happen
        this.ToastLooping = true;
    }

    // same as slicing an order but we need it to be re-runnable during the sliced
    public void ReSliceMuttering(){
        // declare variables
        Sprite mutteringSpriteSelection = this.PlaceHolderSpeechSprite;
        Sprite[] mutteringSpriteList = {};

        // gather language based data
        switch (this.SpeechStatus) {
            // not muttering
            default:
                // huh? que pasa?
                break;
            // muttering rolling
            case SpeechMode.MutteringEnglish:
                // choose from english list
                mutteringSpriteList = this.MutteringEnglishSpriteList;
                break;
            case SpeechMode.MutteringFrench:
                // choose from french list
                mutteringSpriteList = this.MutteringFrenchSpriteList;
                break;
        }

        // do we have options?
        if( mutteringSpriteList.Length > 0 ){
            // roll for an option
            int randomSpriteIndex = Random.Range(0, mutteringSpriteList.Length);
            // retrieve the option
            mutteringSpriteSelection = mutteringSpriteList[randomSpriteIndex];
        }
        // otherwise using the placeholder still
        // else {  }

        // update the sprite ready for use
        this.MutteringElement.sprite = mutteringSpriteSelection;
    }

    // ________________
    // handling orders \\
    // ==========================================
    
    public void SetToOrder( CoffeeOrder OrderInput ){
        this.NewBubbleOrder = OrderInput;
        this.InterruptRudely();
    }

    // this processes the order information and moves us in to sliced state
    public void SliceOrder(){
        // find the indices

        int sizeIndex      = (int)this.NewBubbleOrder.drinkSize;
        int typeIndex      = (int)this.NewBubbleOrder.drinkType;
        int milkIndex      = (int)this.NewBubbleOrder.milk;
        int sweetenerIndex = (int)this.NewBubbleOrder.sweetener;
        
        // set the sprites

        this.SizeElement.sprite = this.SizeSpriteList[sizeIndex];
        this.TypeElement.sprite = this.TypeSpriteList[typeIndex];
        this.MilkElement.sprite = this.MilkSpriteList[milkIndex];
        this.SweetenerElement.sprite = this.SweetenerSpriteList[sweetenerIndex];

        // clear the old order data
        
        this.NewBubbleOrder = null;

        // rice pine lime splice thrice mice dice

        this.BubbleStatus = SpeechBubbleState.Sliced;
    }

    // _______________________
    // interruption functions \\
    // ==========================================

    // dramatically die next time we wake up
    public void InterruptPolitely(){
        this.Stabbed = true;
    }
    // jump straight to dying
    public void InterruptRudely(){
        this.BubbleStatus = SpeechBubbleState.DiedDead;
    }

    // ________________
    // unity functions \\
    // ==========================================

    // Start is called before the first frame update
    void Start()
    {
        // ...
    }

    // Update is called once per frame
    void Update()
    {
        switch (this.BubbleStatus) {
            
            default:
                break;
            case SpeechBubbleState.Inactive:
                this.BubbleState_OnInactive();
                break;
            case SpeechBubbleState.Existing:
                this.BubbleState_OnExisting();
                break;
            case SpeechBubbleState.Sliced:
                this.BubbleState_OnSliced();
                break;
            case SpeechBubbleState.Toasting:
                this.BubbleState_OnToasting();
                break;
            case SpeechBubbleState.Popped:
                this.BubbleState_OnPopped();
                break;
            case SpeechBubbleState.Snoring:
                this.BubbleState_OnSnoring();
                break;
            case SpeechBubbleState.Awoken:
                this.BubbleState_OnAwoken();
                break;
            case SpeechBubbleState.DiedDead:
                this.BubbleState_OnDiedDead();
                break;
        }
    }
}
