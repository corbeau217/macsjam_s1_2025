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
    public CashRegister CashRegisterReference;

    // ================================================

    // ========================================================
    // ========================================================


    // ========================================================
    // ========================================================

    public void HandleOrderComplete( int[] OrderDetails ){
        // get total 
        int orderErrorCount = this.CustomerManagerObj.currentCustomer.order.GetErrorCountInTransaction( OrderDetails );
        // tell them about the order and if it matched
        this.CustomerManagerObj.notifyTransactionComplete( orderErrorCount );
        this.CashRegisterReference.ProcessTransaction( OrderDetails, orderErrorCount );
    }

    // ========================================================
    // ========================================================


    // Start is called before the first frame update
    void Start()
    {
        // ...
    }

    // Update is called once per frame
    void Update()
    {
        // ...
    }

    // ========================================================
    // ========================================================

}
