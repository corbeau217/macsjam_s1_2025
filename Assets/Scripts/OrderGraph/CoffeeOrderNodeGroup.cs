using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeOrderNodeGroup : MonoBehaviour
{
    // ========================================================
    // ========================================================

    public CoffeeOrderNodeController[] NodeList;
    public GameObject SelfReference;

    private KeyCode[] GroupHotkeys;

    // ========================================================
    // ========================================================

    public void SetActiveNode( int InputNodeID ){
        for (int i = 0; i < this.NodeList.Length; i++) {
            this.NodeList[i].SetActiveStatus(i == InputNodeID);
        }
    }

    public void SetAllActiveStatus( bool StatusToSet ){
        for (int i = 0; i < this.NodeList.Length; i++) {
            this.NodeList[i].SetActiveStatus(StatusToSet);
        }
    }

    public void SetActiveStatus( bool StatusToSet ){
        this.SelfReference.SetActive( StatusToSet );
    }

    public KeyCode[] GetGroupHotkeys(){
        return this.GroupHotkeys;
    }

    // ========================================================
    // ========================================================

    // Start is called before the first frame update
    void Start() {
        // gathering the hotkeys for this group
        this.GroupHotkeys = new KeyCode[this.NodeList.Length];
        for (int index = 0; index < this.NodeList.Length; index++) {
            this.GroupHotkeys[index] = this.NodeList[index].Hotkey;
        }
    }

    // Update is called once per frame
    void Update() {
        // ...
    }

    // ========================================================
    // ========================================================
}
