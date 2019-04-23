using Ball;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState { None = -1, MainMenu = 0, GameSettings = 1, Settings = 2, HighScore = 3, GamePlay = 4, Pause = 5}

public class GameManager : Singleton<GameManager>
{
    public GameState state = GameState.None;
    [SerializeField] MenuInflator userInterfaceInflator = null;
    [SerializeField] Transform uiColliderFolder = null;
    [SerializeField] Recycler recycler = null;
    [SerializeField] GameSettings settings = null;
    [SerializeField] AudioSource themeSong = null;
    [SerializeField] Transform audioFolder = null;
    [SerializeField] SceneLoader sceneLoader = null;
    [SerializeField] Eraser eraser = null;
    [SerializeField] Launcher[] launchers = new Launcher[4];
    public float Gravity { get => settings.Gravity; }
    public bool[] BallTypes { get => settings.Balls; }
    public bool NoBall
    {
        get
        {
            foreach (bool has in BallTypes)
                if (has)
                    return false;

            return true;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        Initialize();
    }

    void Start()
    {
        ChangeState(0);
    }

    public void Initialize()
    {
        sceneLoader.Load(1);
        state = GameState.None;
        ProtectGameObjects();
        PlayThemeSong(true);
    }

    public void ProtectGameObjects()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(recycler);
        DontDestroyOnLoad(userInterfaceInflator);
        DontDestroyOnLoad(audioFolder);
        DontDestroyOnLoad(uiColliderFolder);
        DontDestroyOnLoad(eraser);
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
        if(s == 0) settings.SetSettings();
        if (s == 4) LoadGameScene();
        ChangeMenu(s);
        state = (GameState)s;
    }

    public void LoadGameScene()
    {
        recycler.ReclaimAll();
        sceneLoader.Load(2);
    }

    public void LoadMenuScene()
    {
        sceneLoader.Load(1);
    }

    public void PlayThemeSong(bool play)
    {
        if (play && !themeSong.isPlaying)
            themeSong.Play();
        else
            themeSong.Stop();
    }

    void ChangeMenu(int to)
    {
        StartCoroutine(userInterfaceInflator.ChangeMenu((int)state, to));
    }

    void ActivateLaunchers(bool enable)
    {
        foreach(Launcher launcher in launchers)
        {
            launcher.Activate(enable);
        }
    }

}
