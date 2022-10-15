using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayTime : MonoBehaviour
{
    [SerializeField] private Timer internalTimer;
    // Start is called before the first frame update
    void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI textmeshPro = gameObject.GetComponent<TextMeshProUGUI>();
        var minutes = Mathf.Floor(internalTimer.TimeLeft / 60);
        var seconds = Mathf.Floor(internalTimer.TimeLeft - (minutes * 60));
        textmeshPro.SetText("{0}: {1}", minutes, seconds);  

    }
}
