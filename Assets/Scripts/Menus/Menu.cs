using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Menu : MenuElement
{
    [SerializeField] MenuElement[] elements = new MenuElement[0];

    public override void Open()
    {
        foreach (MenuElement menuElement in elements)
        {
            menuElement.Open();
        }
    }

    public override void Close()
    {
        foreach (MenuElement menuElement in elements)
        {
            menuElement.Close();
        }
    }


}
