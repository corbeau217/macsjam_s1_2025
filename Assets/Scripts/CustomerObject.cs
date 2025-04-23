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
    private GameObject StoreEntrance;
    private GameObject OrderingLocation;
    private GameObject StoreExit;

    // ================================================
    
    public CustomerObject customer_behind;
    public CustomerObject customer_inFront;

    // ================================================

    // the customer instance to make sure we can access it
    public GameObject CustomerInstance;
    public SpriteRenderer CustomerSprite;
    public SpeechBubbleController speechBubble;
    
    // enum for our customer movement state
    public TargetLocation target = TargetLocation.Entry;

    // how fast to move
    public float baseMovementSpeed;
    
    // for detecting if we need to update anything
    public bool isMoving = false;

    // how much space they want to leave to the next person
    public float desiredPersonalSpace = 3.5f;

    // ================================================

    public float exitProximityToTeleport = 1.0f; 

    public float MINIMUM_HONKSHOO = 5.0f;
    public float MAXIMUM_HONKSHOO = 15.0f;

    public float orderingSpeechProximity = 1.0f;

    public float sleepLeftSinceLastOrder = 0.0f;

    private bool announcedOrder = false;
    // ================================================


    private CoffeeOrder order = new CoffeeOrder(0,0);
    
    // ================================================

    // ========================================================
    // ========================================================


    public void provideLocations(GameObject entry, GameObject ordering, GameObject exit){
        this.StoreEntrance = entry;
        this.OrderingLocation = ordering;
        this.StoreExit = exit;
        this.target = TargetLocation.Entry;
        this.rerollSprite();
    }

    // ========================================================
    // ========================================================

    void rerollSprite(){
        // deeply cursed that length is capitalised in c#
        int newSpriteID = Random.Range(0,this.sprite_options.Length);
        this.CustomerSprite.sprite = this.sprite_options[newSpriteID];
        // laziness, just remove this later
        if(newSpriteID == 1){
            this.CustomerSprite.flipX = true;
        }
        else {
            this.CustomerSprite.flipX = false;
        }
    }

    void resetCustomer(){
        this.isMoving = false;
        this.announcedOrder = false;
        this.CustomerInstance.transform.position = this.StoreEntrance.transform.position;
        this.target = TargetLocation.Ordering;
        this.sleepLeftSinceLastOrder = 0.0f;
        this.rerollSprite();
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

    public void leaveStore(){
        this.target = TargetLocation.Exit;
        // this.inStore = true;
        this.isMoving = true;
        // print("leaving store");
        this.speechBubble.interruptBubble();
    }

    // when not in store we want to enter the store
    public void startOrdering(){
        this.order.randomiseCoffeeOrder();
        this.speechBubble.setCoffeeOrder(this.order);
        this.target = TargetLocation.Ordering;
        this.isMoving = true;
    }

    // ========================================================
    // ========================================================

    // check for near the exit and mark us as being able to teleport to entrance
    void testExitProximity(){
        float distance_to_exit = Vector3.Distance(this.CustomerInstance.transform.position, this.StoreExit.transform.position);

        // check for too far
        if(distance_to_exit > exitProximityToTeleport){
            // print("too far");
            return;
        }
        
        this.resetCustomer();
    }

    // shouts our order
    void testOrderingProximity(){
        
        float distanceToOrderWindow = Vector3.Distance(this.CustomerInstance.transform.position, this.OrderingLocation.transform.position);
        // when near the window and not sleepy
        if( distanceToOrderWindow < this.orderingSpeechProximity && !announcedOrder){
            this.announceOrder();
        }
    }

    // ========================================================
    // ========================================================


    // for handling the movement
    void approachTarget(GameObject targetObj, GameObject obstacleObj){
        // how to obstacle
        float distance_to_obstacle = Vector3.Distance(this.CustomerInstance.transform.position, obstacleObj.transform.position);
        // check we want to move forward
        if(distance_to_obstacle > this.desiredPersonalSpace){
            // move towards the destination
            this.CustomerInstance.transform.position = Vector3.MoveTowards(this.CustomerInstance.transform.position, targetObj.transform.position, this.baseMovementSpeed * Time.deltaTime);
        }
        else {
            Vector3 movement = new Vector3(-(this.baseMovementSpeed * Time.deltaTime), 0, 0);
            // move towards the destination
            this.CustomerInstance.transform.position = this.CustomerInstance.transform.position + movement;
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
        print("i want a "+this.order.toString()+" please!\n");
        this.speechBubble.showBubble();
        this.sleepLeftSinceLastOrder = Random.Range(MINIMUM_HONKSHOO, MAXIMUM_HONKSHOO);
        this.announcedOrder = true;
    }

    // ========================================================
    // ========================================================

    // Start is called before the first frame update
    void Start()
    {

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
                break;
            case TargetLocation.Exit:
                // heading to exit state
                // interrupt any active bubbles
                this.speechBubble.interruptBubble();
                break;
            default:
                break;
        }

        // snore
        this.sleepLeftSinceLastOrder = Mathf.Max( this.sleepLeftSinceLastOrder - Time.deltaTime, 0.0f );

        if(this.sleepLeftSinceLastOrder == 0.0f){ this.announcedOrder = false; }

        this.updatePosition();
    }

    // ========================================================
    // ========================================================

}
