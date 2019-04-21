using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float scale = 2f;

    public void Scale()
    {
        float width = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;
        transform.localScale = new Vector3(transform.localScale.x * width / scale, transform.localScale.y * width / scale, 1f);
    }
}
