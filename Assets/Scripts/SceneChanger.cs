using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public KeyCode Hotkey;
    string GameSceneName = "MainGameLoop";

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
            SceneManager.LoadScene(this.GameSceneName);
        }
    }
}
