using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Initialization : MonoBehaviour
{
    [SerializeField] UnityEvent onAwake = null;
    [SerializeField] UnityEvent onEnable = null;
    [SerializeField] UnityEvent onStart = null;
    [SerializeField] UnityEvent onLateStart = null;

    void Awake()
    {
        onAwake?.Invoke();
    }

    void OnEnable()
    {
        onEnable?.Invoke();
    }

    void Start()
    {
        onStart?.Invoke();
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForEndOfFrame();
        onLateStart?.Invoke();
    }
}