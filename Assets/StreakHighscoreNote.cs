using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreakHighscoreNote : MonoBehaviour
{
    public PlayerData player;
    public WholeNumberCharDisplayer numberDisplayObject;
    public SpriteRenderer strikethroughSprite;

    // Start is called before the first frame update
    void Start()
    {
        // ...
    }

    // Update is called once per frame
    void Update()
    {
        numberDisplayObject.SetValue(player.streakHighscore);
        strikethroughSprite.enabled = player.streakHighscoreStrikethrough;
    }
}
