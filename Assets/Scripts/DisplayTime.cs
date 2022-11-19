using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTime : MonoBehaviour
{
    [SerializeField] private Timer internalTimer;

    void Update()
    {
        var text = gameObject.GetComponent<Text>();
        var minutes = Mathf.Floor(internalTimer.TimeLeft / 60);
        var seconds = Mathf.Floor(internalTimer.TimeLeft - (minutes * 60));
        text.text = (seconds >= 10) ? $"{minutes}:{seconds}" : $"{minutes}:0{seconds}";
    }
}
