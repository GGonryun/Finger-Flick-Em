using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableableElement : MenuElement
{
    public override IEnumerator Open()
    {
        gameObject.SetActive(true);
        yield return null;
    }

    public override IEnumerator Close()
    {
        gameObject.SetActive(false);
        yield return null;
    }
}
