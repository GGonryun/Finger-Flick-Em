using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] float duration = 1.5f;
    [SerializeField] float speed = 0.05f;
    [SerializeField] Text baseText = null;
    [SerializeField] Text decimalText = null;
    [SerializeField] Text bonus = null;
    bool active = false;
    float score = 0f;

    public void ResetScore()
    {
        DisplayScore(0.0f);
    }

    public void IncreaseScore(float points)
    {
        if (active)
        {
            StopCoroutine(LerpScore(points));
        }
        StartCoroutine(LerpScore(points));
        //if (trickle == 0.0f)
        //    StartCoroutine(TrickleScore(points));
        //else
        //    trickle += points;
    }

    public IEnumerator LerpScore(float points, bool compound = false)
    {
        active = true;
        float start = 0f;
        float end = 0f;
        if (compound)
        {
            start = score;
            score += points;
            end = score;
        }
        else
        {
            end = points;
        }

        float elapsedTime = 0.0f;
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            t = Mathf.Sin(t * Mathf.PI * 0.5f); //ease out.

            DisplayScore(Mathf.Lerp(start, end, t));

            yield return new WaitForSeconds(speed);
            elapsedTime += speed;
        }
        active = false;
    }

    void DisplayScore(float currentPoints)
    {
        int b = (int)currentPoints;
        int f = (int)((currentPoints - b) * 1000);

        baseText.text = b.ToString();
        decimalText.text = f.ToString();
    }
}
