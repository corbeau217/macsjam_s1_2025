using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeBoardNote : MonoBehaviour
{
    public RandomSpriteList NoteShapeList;
    public RandomSpriteList NoteContentList;

    public SpriteRenderer NoteShape;
    public SpriteRenderer NoteContent;

    public bool RandomiseShape = true;
    public bool RandomiseContent = false;

    public void TryRandomise(RandomSpriteList list, SpriteRenderer destination, bool shouldRandomise){
        // want to and exist
        if( shouldRandomise && destination != null && list != null ){
            // roll
            destination.sprite = list.GetSprite();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.TryRandomise(this.NoteShapeList, this.NoteShape, this.RandomiseShape);
        this.TryRandomise(this.NoteContentList, this.NoteContent, this.RandomiseContent);
    }

    // Update is called once per frame
    void Update()
    {
        // ...
    }
}
