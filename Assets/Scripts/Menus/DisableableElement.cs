using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableableElement : MenuElement
{
    public override void Open()
    {
        Debug.Log("Greetings!");
        gameObject.SetActive(true);
    }

    public override void Close()
    {
        Debug.Log("Goodbye");
        gameObject.SetActive(false);
    }
}
