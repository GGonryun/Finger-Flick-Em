using System.Collections;
using UnityEngine;

public class MenuInflator : MonoBehaviour
{
    [SerializeField] MenuElement[] menus = new MenuElement[0];

    public IEnumerator ChangeMenu(int disable, int enable)
    {
        if(disable >= 0)
            yield return StartCoroutine(Deflate(disable));
        yield return StartCoroutine(Inflate(enable));
    }

    IEnumerator Inflate(int i)
    {
        yield return StartCoroutine(menus[i].Open());
    }

    IEnumerator Deflate(int i)
    {
        yield return StartCoroutine(menus[i].Close());
    }
}
