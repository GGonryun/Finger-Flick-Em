using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlideIn : MonoBehaviour
{
    RectTransform rectTransform;
    [SerializeField] float duration = 0;
    [SerializeField] float initialPosition = 0.0f;
    [SerializeField] Direction enterFromDirection = Direction.Up;
    [SerializeField] float delay = 0;
    [SerializeField] UnityEvent OnComplete;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        StartCoroutine(Slide(initialPosition, duration));
    }

    IEnumerator Slide(float startingPosition, float time)
    {
        yield return new WaitForSeconds(delay);

        float elapsedTime = 0.0f;
        float endingPosition = 0.0f;

        while (elapsedTime < time)
        {
            float t = elapsedTime / time;
            t = t * t * (3f - 2f * t);
            float value = Mathf.Lerp(startingPosition, endingPosition, t);

            rectTransform.anchoredPosition = Directions.ToVector2[enterFromDirection] * value;
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
        }
        OnComplete.Invoke();
    }
}
