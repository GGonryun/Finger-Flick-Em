using System.Collections;
using UnityEngine;

public class MenuInflator : MonoBehaviour
{
    [SerializeField] MenuElement[] menus;

    public IEnumerator Inflate(int i)
    {
        yield return StartCoroutine(menus[i].Open());
    }

    public IEnumerator Deflate(int i)
    {
        yield return StartCoroutine(menus[i].Close());
    }
}
