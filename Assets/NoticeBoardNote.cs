using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeBoardNote : MonoBehaviour
{
    public Sprite[] NoteShapeOptions;
    public Sprite[] NoteContentOptions;

    public SpriteRenderer NoteShape;
    public SpriteRenderer NoteContent;

    public bool RandomiseShape = true;
    public bool RandomiseContent = false;

    public void TryRandomise(Sprite[] options, SpriteRenderer destination, bool shouldRandomise){
        if(
            // want to
            shouldRandomise &&
            // they exist
            destination != null &&
            options != null &&
            // have choices
            options.Length > 0
        ){
            // roll
            int index = Random.Range(0, options.Length);
            destination.sprite = options[index];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.TryRandomise(this.NoteShapeOptions, this.NoteShape, this.RandomiseShape);
        this.TryRandomise(this.NoteContentOptions, this.NoteContent, this.RandomiseContent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
