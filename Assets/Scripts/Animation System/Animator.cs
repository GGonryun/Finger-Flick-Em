using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Animation
{
    /// <summary>
    /// Attach this script to an object to animate it, values CANNOT be changed during runtime.
    /// </summary>
    public class Animator : MonoBehaviour
    {
        [SerializeField] Vector2 startingPosition = Vector2.zero;
        [SerializeField] Vector2 endingPosition = Vector2.zero;
        [SerializeField] float duration = 0f;
        [SerializeField] float delay = 0f;
        [SerializeField] Type type = Type.None;
        [SerializeField] UnityEvent OnComplete = null;

        /// <summary>
        /// Animates the UI object this script is attached to.
        /// </summary>
        public void Animate()
        {
            StartCoroutine(Helper(Factory.Get(type)));
        }

        #region BLACKBOX
        /// <summary>
        /// Delays the invocation the Animation and OnComplete.
        /// </summary>
        IEnumerator Helper(Animation animation)
        {
            yield return new WaitForSeconds(delay);

            yield return StartCoroutine(
                animation.Animate(
                    set: (newPosition) => RectTransform.anchoredPosition = newPosition,
                    startingPosition,
                    endingPosition,
                    duration
                )
            );

            OnComplete.Invoke();
        }
        RectTransform _rectTransform;
        RectTransform RectTransform
        {
            get
            {
                if (_rectTransform == null)
                {
                    _rectTransform = GetComponent<RectTransform>();
                }
                return _rectTransform;
            }
        }
        #endregion BLACKBOX
    }
}
