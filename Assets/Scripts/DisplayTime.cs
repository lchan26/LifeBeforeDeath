using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayTime : MonoBehaviour
{
    public Timer internalTimer;
    // Start is called before the first frame update
    void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI textmeshPro = gameObject.GetComponent<TextMeshProUGUI>();
        textmeshPro.SetText("{0}",internalTimer.TimeLeft);
        

    }
}
