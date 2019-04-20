using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : Singleton<GameSettings>
{

    private float _audio = .5f;
    public float Audio
    {
        get => _audio;
        set
        {
            if(value < 0.0f || value > 100.0f)
            {
                throw new System.ArgumentOutOfRangeException($"The audio level must be within 0 - 100: You passed {value}.");
            }

            AudioListener.volume = _audio = value;
        }
    }

}
