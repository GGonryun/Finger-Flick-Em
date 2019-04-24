using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{
    public void Explode(Vector3 point)
    {
        Debug.Log("Sparkles!");
    }

    public void Bounce(Vector3 point)
    {
        Debug.Log("Dust!");
    }
}
