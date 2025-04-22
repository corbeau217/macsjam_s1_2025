using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TargetLocation;

public class CustomerObject : MonoBehaviour
{

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

    public float MINIMUM_HONKSHOO = 2.0f;
    public float MAXIMUM_HONKSHOO = 6.0f;

    // ================================================

    private float sleepLeftSinceLastOrder = 0.0f;
    
    // ================================================

    // ========================================================
    // ========================================================


    public void provideLocations(GameObject entry, GameObject ordering, GameObject exit){
        this.StoreEntrance = entry;
        this.OrderingLocation = ordering;
        this.StoreExit = exit;
        this.target = TargetLocation.Entry;
    }

    // ================================================

    public void leaveStore(){
        this.target = TargetLocation.Exit;
        // this.inStore = true;
        this.isMoving = true;
        // print("leaving store");
    }

    // when not in store we want to enter the store
    public void startOrdering(){
        this.target = TargetLocation.Ordering;
        this.isMoving = true;
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

    // check for near the exit and mark us as being able to teleport to entrance
    void testExitProximity(){
        float distance_to_exit = Vector3.Distance(this.CustomerInstance.transform.position, this.StoreExit.transform.position);

        // check for too far
        if(distance_to_exit > exitProximityToTeleport){
            // print("too far");
            return;
        }
        
        this.teleportToEntrance();

        this.target = TargetLocation.Ordering;
        this.isMoving = false;
        this.sleepLeftSinceLastOrder = Random.Range(MAXIMUM_HONKSHOO, MINIMUM_HONKSHOO);
    }

    // for use when we're meant to be at the entrance / starting to order
    void teleportToEntrance(){
        this.CustomerInstance.transform.position = this.StoreEntrance.transform.position;
    }

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
        // when sleep left
        else if(this.sleepLeftSinceLastOrder > 0.0f){
            // snore
            this.sleepLeftSinceLastOrder = Mathf.Max( this.sleepLeftSinceLastOrder - Time.deltaTime, 0.0f );
        }
        // when otherwise
        else {
            this.isMoving = true;
        }
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
        this.updatePosition();
    }

    // ========================================================
    // ========================================================

}
