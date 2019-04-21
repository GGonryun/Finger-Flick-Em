using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState { None = -1, MainMenu = 0, GameSettings = 1, Settings = 2, HighScore = 3, GamePlay = 4, Pause = 5}

public class GameManager : Singleton<GameManager>
{
    public GameState state = GameState.None;
    [SerializeField] MenuInflator menuInflator = null;
    [SerializeField] Recycler recycler = null;
    [SerializeField] GameSettings settings = null;
    [SerializeField] Launcher[] launchers = new Launcher[4];
    [SerializeField] AudioSource themeSong = null;
    public void Initialize()
    {
        state = GameState.None;
        ProtectGameObjects();
        PlayThemeSong(true);
    }

    public void ProtectGameObjects()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(recycler);
        DontDestroyOnLoad(settings);
        DontDestroyOnLoad(menuInflator);
    }

    public void CloseApplication()
    {
#if UNITY_EDITOR_WIN
        Debug.Log("In Unity Editor!");
#else
                Application.Quit();
#endif
    }

    public void ChangeState(int s)
    {
        ActivateLaunchers(s == 0 ? true : false);
        if (s == 4) settings.StartGame();
        ChangeMenu(s);
        state = (GameState)s;
    }

    public void PlayThemeSong(bool play)
    {
        if (play)
            themeSong.Play();
        else
            themeSong.Stop();
    }

    void ChangeMenu(int to)
    {
        StartCoroutine(menuInflator.ChangeMenu((int)state, to));
    }

    void ActivateLaunchers(bool enable)
    {
        foreach(Launcher launcher in launchers)
        {
            launcher.Activate(enable);
        }
    }

    int currentMenu = 0;
}
