using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UserInput : MonoBehaviour
{
    public UnityEvent OnUserInput = null;
    public KeyCode userInput = KeyCode.Q;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(userInput))
            OnUserInput?.Invoke();
    }   
}
