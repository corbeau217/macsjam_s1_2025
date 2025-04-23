using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeOrderNodeGroup : MonoBehaviour
{
    // ========================================================
    // ========================================================

    public SpriteRenderer[] NodeList;
    public GameObject SelfReference;

    // ========================================================
    // ========================================================

    public void SetActiveNode( int InputNodeID ){
        for (int i = 0; i < this.NodeList.Length; i++) {
            this.NodeList[i].enabled = i == InputNodeID;
        }
    }

    public void SetAllActiveStatus( bool StatusToSet ){
        for (int i = 0; i < this.NodeList.Length; i++) {
            this.NodeList[i].enabled = StatusToSet;
        }
    }

    public void SetActiveStatus( bool StatusToSet ){
        this.SelfReference.SetActive( StatusToSet );
    }

    // ========================================================
    // ========================================================

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    // ========================================================
    // ========================================================
}
