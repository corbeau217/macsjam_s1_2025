using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string DestinationScene;
    public GameClock clock;
    public KeyCode Hotkey;
    public bool WarpToShiftStartOnActivate = false;

    // Start is called before the first frame update
    void Start()
    {
        // ...
    }

    // Update is called once per frame
    void Update()
    {
        this.HandleInput();
    }

    public void HandleInput(){
        if(Input.GetKey(this.Hotkey)){
            if(this.WarpToShiftStartOnActivate){ this.clock.TimewarpToShiftStart(); }
            SceneManager.LoadScene(this.DestinationScene);
        }
    }
}
