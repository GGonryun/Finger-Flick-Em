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
    [SerializeField] ScoreKeeper scoreKeeper = null;
    [SerializeField] ParticleLauncher particleLauncher = null;
    [SerializeField] Spawner spawner = null;
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
        recycler.ReclaimAll();
        if (s == 4) LoadGameScene();
            ChangeMenu(s);
        state = (GameState)s;
    }

    public void LoadGameScene()
    {
        scoreKeeper.ResetScore();
        sceneLoader.Load(2);
        SpawnBall();
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

    #region SCORE SUBSYSTEM
    int bounces = 1;

    public void IncreaseScore(Ball.Ball ball)
    {
        if (state == 0) return;

        float velocityBonus = ball.SquaredVelocity < 100f ? 1f : (ball.SquaredVelocity < 200f ? settings.VelocityMultiplier/3f : (ball.SquaredVelocity < 400f ? settings.VelocityMultiplier/2f : settings.VelocityMultiplier));
        Debug.Log($"Velocity: {ball.SquaredVelocity}, Multiplier: {velocityBonus}");
        float score = ball.Value * (bounces * settings.BounceMultiplier) * (velocityBonus);
        scoreKeeper.IncreaseScore(score);
        ReclaimBall(ball);
        SpawnBall();
    }

    void CountBounce(object sender, BounceEventArgs e)
    {
        bounces++;
        particleLauncher.Bounce(e.Location);
    }

    void ResetBounceCounter(object sender, System.EventArgs e)
    {
        bounces = 0;
    }
    #endregion SCORE SUBSYSTEM

    void SpawnBall()
    {
        Ball.Ball ball = spawner.SpawnBall();
        ball.OnBounce += CountBounce;
        ball.OnFreeze += ResetBounceCounter;
        bounces = 1;
    }

    void ReclaimBall(Ball.Ball ball)
    {
        ball.OnBounce -= CountBounce;
        ball.OnFreeze -= ResetBounceCounter;
        ball.Reclaim();
        particleLauncher.Explode(ball.transform.position);
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
