using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSetter : MonoBehaviour
{
    [SerializeField] Transform[] walls = new Transform[0];
    [SerializeField] Sprite sprite = null;
    //BoxCollider2D[] walls = new BoxCollider2D[0];
    void OnValidate()
    {
        if (walls.Length != 4)
        {
            Debug.LogError("Insufficient walls added to WallSetter must have at least 4 walls.");
        }
    }

    void Start()
    {
      
        float spriteWidth = sprite.textureRect.width / sprite.pixelsPerUnit;
        float spriteHeight = sprite.textureRect.height / sprite.pixelsPerUnit;

        //Set Right Wall
        walls[0].position = new Vector2(ScreenManager.Right, 0f);
        walls[0].localScale = new Vector2(0.25f, ScreenManager.Height/spriteHeight);

        //Set Left Wall
        walls[1].position = new Vector2(ScreenManager.Left, 0f);
        walls[1].localScale = new Vector2(0.25f, ScreenManager.Height/spriteHeight);

        //Set floor
        walls[2].position = new Vector2(0f, ScreenManager.Bottom);
        walls[2].localScale = new Vector2(ScreenManager.Width/spriteWidth/2, 0.25f);

        //Set Roof
        walls[3].position = new Vector2(0f, ScreenManager.Top);
        walls[3].localScale = new Vector2(ScreenManager.Width/spriteWidth/2, 0.25f);

        ////Set right wall
        //walls[0].offset = new Vector2(ScreenManager.Right, 0f);
        //walls[0].size = new Vector2(0.25f, ScreenManager.Height);

        ////Set left Wall
        //walls[1].offset = new Vector2(ScreenManager.Left, 0f);
        //walls[1].size = new Vector2(0.25f, ScreenManager.Height);

        ////Set floor
        //walls[2].offset = new Vector2(0f, ScreenManager.Bottom);
        //walls[2].size = new Vector2(ScreenManager.Width, 0.25f);

        ////Set roof
        //walls[3].offset = new Vector2(0f, ScreenManager.Top);
        //walls[3].size = new Vector2(ScreenManager.Width, 0.25f);
    }
}
