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

    // ================================================

    // ========================================================
    // ========================================================


    // ========================================================
    // ========================================================

    public void HandleOrderComplete( int[] OrderDetails ){
        // get the status
        bool wasOrderCorrect = this.CustomerManagerObj.currentCustomer.order.MatchWithGroupSelectionIDs( OrderDetails );
        // tell them about the order and if it matched
        this.CustomerManagerObj.notifyOrderComplete( wasOrderCorrect );
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
        
    }

    // ========================================================
    // ========================================================

}
