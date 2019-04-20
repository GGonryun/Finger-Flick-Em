using System.Collections.Generic;
using UnityEngine;

public enum Direction { Up, Down, Left, Right }

public static class Directions
{
    public static Dictionary<Direction, Vector2> ToVector2 = new Dictionary<Direction, Vector2>(4)
    {
        {Direction.Up, Vector2.up },
        {Direction.Down, Vector2.down },
        {Direction.Left, Vector2.left },
        {Direction.Right, Vector2.right }
    };
}