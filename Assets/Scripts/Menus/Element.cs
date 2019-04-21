using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Element : MenuElement
{
    public Animation.Animator openAnimation;
    public Animation.Animator closeAnimation;

    [SerializeField] MenuElement[] elements = new MenuElement[0];

    public override void Open()
    {
        openAnimation.Animate();
        foreach (MenuElement menuElement in elements)
        {
            menuElement.Open();
        }
    }

    public override void Close()
    {
        closeAnimation.Animate();
        foreach(MenuElement menuElement in elements)
        {
            menuElement.Close();
        }
    }

}
