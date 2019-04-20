using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Recycler recycler;
    public GameSettings settings;

    public void Awake()
    {
        ProtectGameObjects();
    }


    void ProtectGameObjects()
    {
        DontDestroyOnLoad(recycler);
        DontDestroyOnLoad(settings);
    }
}
