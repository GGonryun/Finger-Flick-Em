using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SequenceMenu : MenuElement
{
    [SerializeField] MenuElement[] elements = new MenuElement[0];

    public override IEnumerator Open()
    {
        foreach (MenuElement menuElement in elements)
        {
            yield return StartCoroutine(menuElement.Open());
        }
    }

    public override IEnumerator Close()
    {
        foreach (MenuElement menuElement in elements)
        {
            yield return StartCoroutine(menuElement.Close());
        }
    }


}
