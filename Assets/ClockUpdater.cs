using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockUpdater : MonoBehaviour
{
    public GameClock clock;

    public bool StartFrozen = false;

    // Start is called before the first frame update
    void Start()
    {
        if(this.StartFrozen){
            this.clock.Freeze();
        }
        else {
            this.clock.Unfreeze();
        }
        this.clock.TimewarpToShiftStart();
    }

    // Update is called once per frame
    void Update()
    {
        this.clock.tick();
    }
}
