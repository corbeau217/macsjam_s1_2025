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

    // the customer instance to make sure we can access it
    public GameObject CustomerInstance;
    
    // enum for our customer movement state
    public TargetLocation target = TargetLocation.Entry;

    // how fast to move
    public float baseMovementSpeed = 5.0f;
    
    // for detecting if we need to update anything
    public bool isMoving = false;

    // public bool inStore = false;

    // ================================================

    public float exitProximityToTeleport = 1.0f; 

    // ================================================

    // ========================================================
    // ========================================================


    public void provideLocations(GameObject entry, GameObject ordering, GameObject exit){
        this.StoreEntrance = entry;
        this.OrderingLocation = ordering;
        this.StoreExit = exit;
    }

    // ================================================

    public void leaveStore(){
        this.target = TargetLocation.Exit;
        // this.inStore = true;
        this.isMoving = true;
    }

    // when not in store we want to enter the store
    public void startOrdering(){
        this.teleportToEntrance();
        this.isMoving = true;
        this.target = TargetLocation.Ordering;
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
            return;
        }
        
        // our target is the entrance now
        this.target = TargetLocation.Entry;
        // we're not moving anymore
        this.isMoving = false;
        // teleporting is legal too
        this.teleportToEntrance();
    }

    // for use when we're meant to be at the entrance / starting to order
    void teleportToEntrance(){
        this.CustomerInstance.transform.position = this.StoreEntrance.transform.position;
    }

    void updatePosition(){
        // prepare our target object
        GameObject targetObj = this.getTargetObject();

        if(this.isMoving){
            // otherwise move towards the destination
            this.CustomerInstance.transform.position = Vector3.MoveTowards(this.CustomerInstance.transform.position, targetObj.transform.position, this.baseMovementSpeed * Time.deltaTime);

            // check for near exit
            if(this.target == TargetLocation.Exit){
                this.testExitProximity();
            }
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
