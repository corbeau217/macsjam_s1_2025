using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TargetLocation;

public class CustomerObject : MonoBehaviour
{
    // ========================================================
    // ========================================================

    public Sprite[] sprite_options;

    // ========================================================
    // ========================================================

    // ================================================

    // location markers
    public GameObject StoreEntrance;
    public GameObject OrderingLocation;
    public GameObject StoreExit;

    // ================================================
    
    public CustomerObject customer_behind;
    public CustomerObject customer_inFront;

    // ================================================

    // the customer instance to make sure we can access it
    public GameObject CustomerInstance;
    public SpriteRenderer CustomerSprite;
    public SpeechController speechBubbleController;
    
    // enum for our customer movement state
    public TargetLocation target = TargetLocation.Entry;

    // how fast to move
    public float baseMovementSpeed;
    
    // for detecting if we need to update anything
    public bool isMoving = false;

    // how much space they want to leave to the next person
    public float desiredPersonalSpace = 3.5f;

    public Vector3 StepBackVector = new Vector3(-2.5f, 0.0f, 0.0f);

    // ================================================

    public float exitProximityToTeleport = 1.0f; 

    public float MINIMUM_ORDERING_HONKSHOO = 4.0f;
    public float MAXIMUM_ORDERING_HONKSHOO = 12.0f;

    public float orderingSpeechProximity = 1.0f;

    public float SleepLeftSinceLastOrdering = 0.0f;

    private bool announcedOrder = false;
    // ================================================


    public CoffeeOrder order = new CoffeeOrder(0,0);
    
    // ================================================

    // ========================================================
    // ========================================================


    public void initialise(){
        this.rerollSprite();
        this.rerollOrder();
        this.target = TargetLocation.Ordering;
        this.isMoving = true;
    }

    // ========================================================
    // ========================================================

    void rerollOrder(){
        this.order.randomiseCoffeeOrder();
    }
    void rerollSprite(){
        // deeply cursed that length is capitalised in c#
        int newSpriteID = Random.Range( 0, this.sprite_options.Length );
        // this.CustomerSprite.sprite = this.sprite_options[newSpriteID];
        this.CustomerSprite.sprite = this.sprite_options[newSpriteID];

        // laziness, just remove this later when sprite is fixed
        if(newSpriteID == 1){
            this.CustomerSprite.flipX = true;
        }
        else {
            this.CustomerSprite.flipX = false;
        }
    }
    
    public bool wantsToOrder(){
        return this.target == TargetLocation.Ordering;
    }

    void resetCustomer(){
        this.isMoving = false;
        this.announcedOrder = false;
        this.CustomerInstance.transform.position = this.StoreEntrance.transform.position;
        this.target = TargetLocation.Ordering;
        this.snoozeOrdering();
        this.rerollSprite();
        this.rerollOrder();
        
    }

    void snoozeOrdering(){
        this.SleepLeftSinceLastOrdering = Random.Range(MINIMUM_ORDERING_HONKSHOO, MAXIMUM_ORDERING_HONKSHOO);
    }

    // ========================================================
    // ========================================================

    GameObject getTargetObject(){
        switch (this.target)
        {
            case TargetLocation.Entry:
            default:
                return this.StoreEntrance;
            case TargetLocation.Ordering:
                return this.OrderingLocation;
            case TargetLocation.Exit:
                return this.StoreExit;
        }
    }

    // ========================================================
    // ========================================================

    public void prepareOrderSpeech(){
        this.speechBubbleController.SetToOrder(this.order);
    }

    public void leaveStore(){
        this.target = TargetLocation.Exit;
        // this.inStore = true;
        this.isMoving = true;
        // print("leaving store");
        this.speechBubbleController.InterruptRudely();
    }

    // ========================================================
    // ========================================================

    // check for near the exit and mark us as being able to teleport to entrance
    void testExitProximity(){
        float distance_to_exit = Vector3.Distance(this.CustomerInstance.transform.position, this.StoreExit.transform.position);

        // close
        if(distance_to_exit <= exitProximityToTeleport){
            this.resetCustomer();
        }
    }

    // shouts our order
    void testOrderingProximity(){
        
        float distanceToOrderWindow = Vector3.Distance(this.CustomerInstance.transform.position, this.OrderingLocation.transform.position);
        // when near the window
        if( distanceToOrderWindow < this.orderingSpeechProximity && !announcedOrder){
            this.announceOrder();
        }
        // // when near the window and not sleepy
        // if( distanceToOrderWindow < this.orderingSpeechProximity && !announcedOrder){
        //     this.announceOrder();
        // }
    }

    // ========================================================
    // ========================================================


    // for handling the movement
    void approachTarget(GameObject targetObj, GameObject obstacleObj){
        // how to obstacle
        float obstacleDistance = Vector3.Distance(this.CustomerInstance.transform.position, obstacleObj.transform.position);
        float targetDistance = Vector3.Distance(this.CustomerInstance.transform.position, targetObj.transform.position);

        // smallest movement distance portion
        float maximumMovementDistance = Mathf.Min(targetDistance, Mathf.Min(obstacleDistance - this.desiredPersonalSpace, this.baseMovementSpeed));


        // check we want to move forward
        if(obstacleDistance > this.desiredPersonalSpace){
            // move towards the destination but 
            this.CustomerInstance.transform.position = Vector3.MoveTowards(this.CustomerInstance.transform.position, targetObj.transform.position, maximumMovementDistance * Time.deltaTime);
        }
        else {
            // probably should save this when we notice it
            Vector3 StepBackPosition = this.CustomerInstance.transform.position + this.StepBackVector;
            // move backwards half speed
            this.CustomerInstance.transform.position =  Vector3.MoveTowards(this.CustomerInstance.transform.position, StepBackPosition, (this.baseMovementSpeed/2.0f) * Time.deltaTime);
        }
    }

    void updatePosition(){
        // prepare our target object
        GameObject targetObj = this.getTargetObject();

        if(this.isMoving){
            // try to move there
            this.approachTarget(targetObj, this.customer_inFront.CustomerInstance);

            // check for near exit
            if(this.target == TargetLocation.Exit){
                this.testExitProximity();
            }
        }
        // when otherwise
        else {
            this.isMoving = true;
        }

        this.testOrderingProximity();
    }

    void announceOrder(){
        // debugging spam
        // print("i want a "+this.order.toString()+" please!\n");

        this.speechBubbleController.SetLooping( true );
        this.announcedOrder = true;
    }

    // ========================================================
    // ========================================================

    public void HandleYuckyOrder( int orderErrorCount ){
        // TODO : how yucky was it? do we talk about it?
    }

    // ========================================================
    // ========================================================

    // Start is called before the first frame update
    void Start()
    {
        // ..
    }

    // handle the time outs
    void snore(){
        this.SleepLeftSinceLastOrdering = Mathf.Max( this.SleepLeftSinceLastOrdering - Time.deltaTime, 0.0f );
    }

    // Update is called once per frame
    void Update()
    {
        switch (this.target){
            case TargetLocation.Entry:
                // heading to entry state
                break;
            case TargetLocation.Ordering:
                // heading to counter state
                // can do a new order?
                if(this.SleepLeftSinceLastOrdering == 0.0f){ this.isMoving = true; }
                break;
            case TargetLocation.Exit:
                // heading to exit state
                // interrupt any active bubbles
                this.speechBubbleController.InterruptRudely();
                break;
            default:
                break;
        }

        // snore
        this.snore();


        this.updatePosition();
    }

    // ========================================================
    // ========================================================

}
