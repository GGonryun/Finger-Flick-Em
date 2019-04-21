using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Decorator class used to turn an element into a toggle.
/// </summary>
public sealed class ParallelToggle : MenuElement
{
    [SerializeField] MenuElement[] elements = new MenuElement[0];

    public void Toggle(bool toggle)
    {
        if(toggle)
            StartCoroutine(Open());
        else
            StartCoroutine(Close());
    }

    public override IEnumerator Close()
    {
        foreach(MenuElement element in elements)
        {
            StartCoroutine(element.Close());
        }
        yield return null;
    }

    public override IEnumerator Open()
    {
        foreach (MenuElement element in elements)
        {
            StartCoroutine(element.Open());
        }
        yield return null;
    }


}
