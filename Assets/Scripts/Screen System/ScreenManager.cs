using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Works best w/ square images!!!
/// </summary>
public class ScreenManager : Singleton<ScreenManager>
{
    public static float Right { get => Current.size.x/2f; }
    public static float Left { get => Current.size.x/-2f; } 
    public static float Top { get => Current.size.y/2f; }
    public static float Bottom { get => Current.size.y/-2f; }
    public static float Width { get => Current.size.x; }
    public static float Height { get => Current.size.y; }
    Vector2 size = Vector2.zero;

    protected override void Awake()
    {
        base.Awake();
        float height = Camera.main.orthographicSize * 2;
        float width = height * Screen.width / Screen.height;
        size = new Vector2(width, height);
    }

    /// <summary>
    /// Works best w/ square images.
    /// </summary>
    public static void FitComponent(SpriteRenderer sr)
    {
        Sprite s = sr.sprite;

        float spriteWidth = s.textureRect.width / s.pixelsPerUnit;
        float spriteHeight = s.textureRect.height / s.pixelsPerUnit;

        sr.transform.localScale = new Vector3(Width / spriteWidth, Height / spriteHeight);
    }
}
