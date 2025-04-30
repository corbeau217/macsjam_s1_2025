using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlipCounter : MonoBehaviour
{
    public SpriteRenderer[] BlipList;
    public AudioSource IncreaseSound;
    public int StartingCount = 0;
    public int CurrentCount = 0;


    public void SetCount( int NewCount ){
        // replace it
        this.CurrentCount = NewCount;
        // update the states
        for (int i = 0; i < this.BlipList.Length; i++) {
            this.BlipList[i].enabled = (i < this.CurrentCount);
        }
    }
    public void UpdateCount( int NewCount ){
        // different count
        if( this.CurrentCount != NewCount ){
            // replace it
            this.CurrentCount = NewCount;
            // update the states
            for (int i = 0; i < this.BlipList.Length; i++) {
                this.BlipList[i].enabled = (i < this.CurrentCount);
            }
        }
    }


    public void AttemptIncreaseSound(){
        if (this.IncreaseSound != null) {
            this.IncreaseSound.Play();
        }
    }
    public void Increase(){
        this.AttemptIncreaseSound();
        this.UpdateCount( Mathf.Min(this.BlipList.Length, this.CurrentCount+1) );

    }

    public void Decrease(){
        this.UpdateCount( Mathf.Max(                   0, this.CurrentCount-1) );
    }

    public bool IsMaximum(){ return this.CurrentCount == this.BlipList.Length; }

    public void ResetCounter(){  this.SetCount( this.StartingCount ); }


    // Start is called before the first frame update
    void Start()
    {
        this.ResetCounter();
    }

    // Update is called once per frame
    void Update()
    {
        // ...
    }
}
