using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum Planets { Earth, Moon, Alien, Jupiter }
public enum Modes { FreePlay, TimeTrial }

public class GameSettings : MonoBehaviour
{
    [System.Serializable]
    class RoundData
    {
        public Planets planet = Planets.Earth;
        public Modes mode = 0;
        public bool[] balls = new bool[5] { false, false, true, false, false };
    }

    [SerializeField] RoundData game = new RoundData();

    [Header("Slider Controls")]
    [SerializeField] Slider audioSlider;
    [SerializeField] Slider animationSlider;
    [SerializeField] AudioSource sliderAudio;

    [Header("Toggle Controls")]
    [SerializeField] ToggleGroup planetGroup;
    [SerializeField] ToggleGroup modeGroup;
    [SerializeField] Toggle[] ballToggles;

    [Header("Defaults")]
    [SerializeField] int defaultAudioLevel = 60;
    [SerializeField] int defaultAnimationSpeed = 75;

    public void StartGame()
    {
        SetBalls();
        SetPlanet();
        SetMode();
    }

    void SetBalls()
    {
        for (int i = 0; i < 5; i++)
        {
            game.balls[i] = ballToggles[i].isOn;
        }
    }

    void SetPlanet()
    {
        Toggle active = planetGroup.ActiveToggles().First();

        string name = active.transform.parent.parent.name;
        switch (name)
        {
            case "Earth":
                game.planet = Planets.Earth;
                return;
            case "Moon":
                game.planet = Planets.Moon;
                return;
            case "Alien":
                game.planet = Planets.Alien;
                return;
            case "Jupiter":
                game.planet = Planets.Jupiter;
                return;
        }
        throw new System.ArgumentOutOfRangeException($"The parameter entered is not a valid: [{name}].");
        
    }

    void SetMode()
    {
        Toggle active = modeGroup.ActiveToggles().First();
        string name = active.gameObject.name;

        switch(name)
        {
            case "Free Play":
                game.mode = Modes.FreePlay;
                return;
            case "Time Trials":
                game.mode = Modes.TimeTrial;
                return;
        }
        throw new System.ArgumentOutOfRangeException($"The parameter entered is not a valid: [{name}].");
    }

    void SetAudioLevel(float value)
    {
        AudioLevel = value;
    }

    void SetAnimationSpeed(float value)
    {
        AnimationSpeed = value / 100f;
    }

    void MakeNoise(float value)
    {
        if (Mathf.RoundToInt(value % 2) == 0)
            sliderAudio.Play();
    }

    void OnEnable()
    {
        audioSlider.onValueChanged.AddListener(SetAudioLevel);
        audioSlider.value = defaultAudioLevel;
        animationSlider.onValueChanged.AddListener(SetAnimationSpeed);
        animationSlider.value = defaultAnimationSpeed;

        audioSlider.onValueChanged.AddListener(MakeNoise);
        animationSlider.onValueChanged.AddListener(MakeNoise);
    }

    void OnDisable()
    {
        audioSlider.onValueChanged.RemoveListener(SetAudioLevel);
        animationSlider.onValueChanged.RemoveListener(SetAnimationSpeed);

        audioSlider.onValueChanged.RemoveListener(MakeNoise);
        animationSlider.onValueChanged.RemoveListener(MakeNoise);
    }

    float AudioLevel
    {
        get => AudioListener.volume;
        set
        {
            if (value < 0.0f || value > 100.0f)
            {
                throw new System.ArgumentOutOfRangeException($"The audio level must be within 0 - 100: You passed {value}.");
            }
            AudioListener.volume = value;
        }
    }
    float AnimationSpeed
    {
        get => Animation.Animator.animationSpeed;
        set
        {
            if (value < 0.0f || value > 100.0f)
            {
                throw new System.ArgumentOutOfRangeException($"Animation speed must be within 0 - 100: You passed {value}.");
            }

            Animation.Animator.animationSpeed = value;
        }
    }
}
