using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ParallelMenu : MenuElement
{
    [SerializeField] MenuElement[] elements = new MenuElement[0];

    public override IEnumerator Open()
    {
        foreach (MenuElement menuElement in elements)
        {
            StartCoroutine(menuElement.Open());
        }
        yield return null;
    }

    public override IEnumerator Close()
    {
        foreach (MenuElement menuElement in elements)
        {
            StartCoroutine(menuElement.Close());
        }
        yield return null;
    }


}
