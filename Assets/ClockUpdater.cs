using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockUpdater : MonoBehaviour
{
    public GameClock clock;

    // Start is called before the first frame update
    void Start()
    {
        this.clock.StartTheDay();
    }

    // Update is called once per frame
    void Update()
    {
        this.clock.tick();
    }
}
