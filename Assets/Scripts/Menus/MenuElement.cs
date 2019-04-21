using System.Collections;
using UnityEngine;

//MAKE THESE INTO COROUTINES.
public abstract class MenuElement : MonoBehaviour
{
    public abstract IEnumerator Open();
    public abstract IEnumerator Close();
}