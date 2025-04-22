using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ========================================================
    // ========================================================

    // ================================================

    // access to the customer manager
    public CustomerManager CustomerManagerObj;

    // time before the next update from keyboard inputs
    public float input_timeout = 0.1f;

    // ================================================

    // how much time left on the sleeping
    private float input_sleeping_left = 0.0f;

    // ================================================

    // ========================================================
    // ========================================================

    // we got sleepy and need to snooze
    void pass_out(){
        this.input_sleeping_left = this.input_timeout;
    }
    // handles the timeout between inputs
    void snore(){
        // cap it at 0 so we dont get negatives
        this.input_sleeping_left = Mathf.Max(0.0f, input_sleeping_left - Time.deltaTime);
    }
    void handle_input(){
        // allowed to check for input

        // loop for space use
        if (Input.GetKey(KeyCode.Space)) {
            // found
            this.handle_order_complete();
            // make us sleepy
            pass_out();
        }
    }
    void handle_order_complete(){
        this.CustomerManagerObj.notifyOrderComplete();
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
        // are we a sleeper
        if(this.input_sleeping_left > 0.0f){
            this.snore();
        }
        else {
            this.handle_input();
        }
    }

    // ========================================================
    // ========================================================

}
