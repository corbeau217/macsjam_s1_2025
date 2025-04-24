using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public class MenuToasterController : MonoBehaviour
{
    public GameObject MenuReference;

    public GameObject HidingLocation;
    public GameObject ToastingLocation;

    public MenuToastState ToastStatus = MenuToastState.Initialising;

    public KeyCode ShowMenuKeyCode = KeyCode.Tab;

    public float toastingMovementSpeed = 7.0f;
    public float hidingMovementSpeed = 10.0f;
    
    public float RelaxSnappingDistance = 1.0f;

    public bool KeyPressDetected_Override = false;

    // ====================================
    // ====================================

    public bool ShouldToast(){
        return KeyPressDetected_Override || Input.GetKey( this.ShowMenuKeyCode );
    }

    // ====================================
    // ====================================

    public void ToastState_OnInitialising(){
        this.SnapToHiding();
        this.ToastStatus = MenuToastState.Ready;
    }
    public void ToastState_OnReady(){
        // should toast?
        if( this.ShouldToast() ){
            this.ToastStatus = MenuToastState.Toasting;
        }
    }
    public void ToastState_OnToasting(){
        if( !this.ShouldToast() ){
            // no longer holding
            this.ToastStatus = MenuToastState.Relaxing;
        }
        else {
            this.MoveTo(this.ToastingLocation.transform.position, this.toastingMovementSpeed);
        }
    }
    public void ToastState_OnRelaxing(){
        if(this.DistanceToObject(this.HidingLocation) < this.RelaxSnappingDistance){
            this.SnapToHiding();
        }
        else{
            this.MoveTo(this.HidingLocation.transform.position, this.hidingMovementSpeed);
        }
    }

    // ====================================
    // ====================================

    public void MoveTo(Vector3 Destination, float Speed){
        // prepare data
        float destinationDistance = this.DistanceToPosition(Destination);

        // restrict our movement to the smallest factor
        float maximumMovementFactor = Mathf.Min(destinationDistance, Speed);

        // only when not 0
        if(destinationDistance > 0.0f){
            this.MenuReference.transform.position = Vector3.MoveTowards( this.MenuReference.transform.position, Destination, maximumMovementFactor * Time.deltaTime );
        }
    }
    public void SnapToHiding(){
        this.MenuReference.transform.position = HidingLocation.transform.position;
    }

    public float DistanceToObject(GameObject InputObject){
        return this.DistanceToPosition(InputObject.transform.position);
    }
    public float DistanceToPosition(Vector3 InputPosition){
        return Vector3.Distance(this.MenuReference.transform.position, InputPosition);
    }

    // ====================================
    // ====================================

    // Start is called before the first frame update
    void Start()
    {
        this.ToastStatus = MenuToastState.Initialising;
        this.ShowMenuKeyCode = KeyCode.Tab;
    }

    // Update is called once per frame
    void Update()
    {
        // go to relevant function
        switch (this.ToastStatus) {
            default:
            case MenuToastState.Initialising:
                this.ToastState_OnInitialising();
                break;
            case MenuToastState.Ready:
                this.ToastState_OnReady();
                break;
            case MenuToastState.Toasting:
                this.ToastState_OnToasting();
                break;
            case MenuToastState.Relaxing:
                this.ToastState_OnRelaxing();
                break;
        }
    }
}
