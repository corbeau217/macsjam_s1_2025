using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubbleController : MonoBehaviour
{
    // for managing the group and if the bubble is shown
    public GameObject SpriteGroup;

    public SpeechSpriteController_Milk spriteController_milk;
    public SpeechSpriteController_Sweetener spriteController_sweetener;

    public CoffeeOrder order = new CoffeeOrder(0, 0);

    public float bubbleFloatingTimeRemaining = 0.0f;
    public float BUBBLE_TOASTING_TIME = 3.5f;
    public float BUBBLE_RANDOM_RANGE = 2.0f;

    public void setCoffeeOrder(CoffeeOrder orderIn){
        this.order = orderIn;
        this.spriteController_milk.setOption( this.order.milk );
        this.spriteController_sweetener.setOption( this.order.sweetener );
    }

    public void showBubble(){
        // randomise the toasting time a bit
        float halfRandomRange = BUBBLE_RANDOM_RANGE/2.0f;
        this.bubbleFloatingTimeRemaining = Random.Range(this.BUBBLE_TOASTING_TIME - halfRandomRange, this.BUBBLE_TOASTING_TIME + halfRandomRange);
        this.SpriteGroup.SetActive(true);
    }

    // end the bubble early
    public void interruptBubble(){
        this.SpriteGroup.SetActive(false);
    }

    private void snore(){
        this.bubbleFloatingTimeRemaining = Mathf.Max(this.bubbleFloatingTimeRemaining - Time.deltaTime, 0.0f);
        // when no longer sleepy
        if(this.bubbleFloatingTimeRemaining == 0.0f){
            this.SpriteGroup.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.snore();
    }
}
