using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Element : MenuElement
{
    public Animation.Animator openAnimation;
    public Animation.Animator closeAnimation;

    [SerializeField] MenuElement[] elements = new MenuElement[0];

    public override IEnumerator Open()
    {
        foreach (MenuElement menuElement in elements)
        {
            yield return StartCoroutine(menuElement.Open());
        }
        yield return StartCoroutine(openAnimation.Animate());
    }

    public override IEnumerator Close()
    {
        yield return StartCoroutine(closeAnimation.Animate());
        foreach(MenuElement menuElement in elements)
        {
            yield return StartCoroutine(menuElement.Close());
        }
    }

}
