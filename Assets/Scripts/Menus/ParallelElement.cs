using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ParallelElement : MenuElement
{
    public Animation.Animator openAnimation;
    public Animation.Animator closeAnimation;

    [SerializeField] MenuElement[] elements = new MenuElement[0];


    public override IEnumerator Open()
    {
        foreach (MenuElement menuElement in elements)
        {
            StartCoroutine(menuElement.Open());
        }
        StartCoroutine(openAnimation.Animate());
        yield return null;
    }

    public override IEnumerator Close()
    {
        StartCoroutine(closeAnimation.Animate());
        foreach(MenuElement menuElement in elements)
        {
            StartCoroutine(menuElement.Close());
        }
        yield return null;
    }

}
