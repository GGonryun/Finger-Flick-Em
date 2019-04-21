using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { None = -1, MainMenu = 0, SubMenu = 1, GamePlay = 2, Pause = 3}

public class GameManager : Singleton<GameManager>
{
    public GameState state = GameState.MainMenu;
    public MenuInflator uiManager = null;
    public Recycler recycler = null;
    public GameSettings settings = null;
    public Launcher[] launchers = new Launcher[4];

    public void ProtectGameObjects()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(recycler);
        DontDestroyOnLoad(settings);
    }
    public void OpenMainMenu()
    {
        StartCoroutine(Inflate(0));
    }

    public void OpenSubMenu(int i)
    {
        StartCoroutine(GoToSubMenu(i));
    }

    public void ExitButton()
    {
        switch(state)
        {
            case GameState.MainMenu:
                CloseApplication();
                break;
            case GameState.SubMenu:
                StartCoroutine(GoToMainMenu(currentMenu));
                break;
            case GameState.GamePlay:
                break;
            case GameState.Pause:
                break;
        }
    }

    IEnumerator GoToSubMenu(int i)
    {
        yield return StartCoroutine(Deflate(0));
        yield return StartCoroutine(Inflate(i));
        ChangeState(i);
    }

    IEnumerator GoToMainMenu(int i)
    {
        yield return StartCoroutine(Deflate(i));
        yield return StartCoroutine(Inflate(0));
        ChangeState(0);
    }

    void CloseApplication()
    {
#if UNITY_EDITOR_WIN
        Debug.Log("In Unity Editor!");
#else
                Application.Quit();
#endif
    }

    IEnumerator Inflate(int i)
    {
        ChangeState(i);

        currentMenu = i;
        yield return uiManager.Inflate(i);
    }

    IEnumerator Deflate(int i)
    {
        yield return uiManager.Deflate(i);
    }

    void ChangeState(int i)
    {
        foreach (Launcher launcher in launchers)
        {
            launcher.Deactivate();
        }
        switch (i)
        {
            case 0:
                foreach (Launcher launcher in launchers)
                {
                    launcher.Activate();
                }
                state = GameState.MainMenu;
                break;
            case 1:
            case 2:
            case 3:
                state = GameState.SubMenu;
                break;
            case 4:
                state = GameState.GamePlay;
                break;
        }
    }

    int currentMenu = 0;
}
