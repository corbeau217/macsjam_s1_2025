using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundsNote : MonoBehaviour
{
    public PlayerData player;
    public WholeNumberCharDisplayer numberDisplayObject;

    // Start is called before the first frame update
    void Start()
    {
        // ...
    }

    // Update is called once per frame
    void Update()
    {
        numberDisplayObject.SetValue(player.totalFunds);
    }
}
