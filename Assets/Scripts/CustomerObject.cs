using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TargetLocation;

public class CustomerObject : MonoBehaviour
{
    // ================================================

    // location markers
    private GameObject StoreEntrance;
    private GameObject OrderingLocation;
    private GameObject StoreExit;

    // ================================================

    public GameObject CustomerInstance;
    public TargetLocation target = TargetLocation.Entry;
    public float baseMovementSpeed = 1.0f;
    public bool inStore = false;
    public bool isMoving = false;

    // ================================================

    public void provideLocations(GameObject entry, GameObject ordering, GameObject exit){
        this.StoreEntrance = entry;
        this.OrderingLocation = ordering;
        this.StoreExit = exit;
    }

    // ================================================

    public void leaveStore(){
        this.target = TargetLocation.Exit;
        inStore = true;
        isMoving = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
