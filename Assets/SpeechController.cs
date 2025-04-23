using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeechController : MonoBehaviour
{
    // _____________
    // sprite group \\
    // ==========================================

    public GameObject SpeechBubbleCollection;

    // ______________
    // sprite layers \\
    // ==========================================

    public SpriteRenderer SizeElement;
    public SpriteRenderer TypeElement;
    public SpriteRenderer MilkElement;
    public SpriteRenderer SweetenerElement;

    // ____________________
    // sprite option lists \\
    // ==========================================

    public Sprite[] SizeSpriteList;
    public Sprite[] TypeSpriteList;
    public Sprite[] MilkSpriteList;
    public Sprite[] SweetenerSpriteList;

    // _________________
    // state variables \\
    // ==========================================

    public SpeechBubbleState BubbleStatus = SpeechBubbleState.Inactive;

    // when we want graceful exiting a bubble loop
    public bool Stabbed = false;

    // ___________________
    // toasting variables \\
    // ==========================================

    public float BubbleToasting_TimeMinimum =  3.0f;
    public float BubbleToasting_TimeMaximum = 6.0f;

    public float BubbleToasting_TimeLeft = 0.0f;

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

    public void SetLooping( bool isLooping ){
        this.ToastLooping = isLooping;
    }

    // _______________________
    // state handle functions \\
    // ==========================================

    public void BubbleState_OnInactive(){
        this.BubbleToasting_TimeLeft = 0.0f;
        this.BubbleSnoring_TimeLeft = 0.0f;
        this.Stabbed = false;
        // ready for slurping up new order
        this.BubbleStatus = SpeechBubbleState.Existing;
    }

    public void BubbleState_OnExisting(){
        // ready for slurping up new order
        if(this.NewBubbleOrder != null ){
            this.SliceOrder();
        }
    }

    public void BubbleState_OnSliced(){
        if(this.ToastLooping){
            // hide the whole collection
            this.SpeechBubbleCollection.SetActive( true );
            // set us up to toast
            this.BubbleToasting_TimeLeft = Random.Range( this.BubbleToasting_TimeMinimum, this.BubbleToasting_TimeMaximum );
            // BZZZRRRRTTT
            this.BubbleStatus = SpeechBubbleState.Toasting;
        }
    }

    public void BubbleState_OnToasting(){
        // lower bound as 0.0f
        this.BubbleToasting_TimeLeft = Mathf.Max(this.BubbleToasting_TimeLeft - Time.deltaTime, 0.0f);
        // check we should awake
        if(this.BubbleToasting_TimeLeft == 0.0f){
            // next update will catch this and update it
            this.BubbleStatus = SpeechBubbleState.Popped;
        }
    }

    public void BubbleState_OnPopped(){
        // hide the whole collection
        this.SpeechBubbleCollection.SetActive( false );
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
        // hide the whole collection
        this.SpeechBubbleCollection.SetActive( false );
        // make it not active
        this.BubbleStatus = SpeechBubbleState.Inactive;
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
