using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audio = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audio.Play();
    }
}
