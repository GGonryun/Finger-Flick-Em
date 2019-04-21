using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInflator : MonoBehaviour
{
    [SerializeField] MenuElement menu;

    public void Inflate()
    {
        StartCoroutine(menu.Open());
    }

    public void Deflate()
    {
        StartCoroutine(menu.Close());
    }
}
