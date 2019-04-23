using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    [SerializeField] Text display = null;

    public void Display(Slider slider)
    {
        display.text = slider.value.ToString();
    }
}
