using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RandomSpriteList", order = 1)]
public class RandomSpriteList : ScriptableObject
{
    public Sprite[] spriteOptionsList;

    public Sprite GetSprite(){
        int index = Random.Range( 0, spriteOptionsList.Length );
        return spriteOptionsList[index];
    }
    public int GetSpriteFor(SpriteRenderer destination){
        int index = Random.Range( 0, spriteOptionsList.Length );
        destination.sprite = spriteOptionsList[index];
        return index;
    }
    public Sprite GetSpecificSprite(int index){
        return this.spriteOptionsList[index];
    }
}
