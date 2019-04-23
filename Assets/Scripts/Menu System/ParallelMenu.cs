using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ParallelMenu : MenuElement
{
    [SerializeField] float delay = 0.01f;
    [SerializeField] MenuElement[] elements = new MenuElement[0];

    public override IEnumerator Open()
    {
        yield return new WaitForSeconds(delay);
        foreach (MenuElement menuElement in elements)
        {
            StartCoroutine(menuElement.Open());
        }
    }

    public override IEnumerator Close()
    {
        foreach (MenuElement menuElement in elements)
        {
            StartCoroutine(menuElement.Close());
        }
        yield return new WaitForSeconds(delay);
    }


}
