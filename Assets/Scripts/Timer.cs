using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Tooltip("The total time limit for this level in seconds")] 
    [SerializeField] private int timeLimit = 120;

    public float TimeLeft { get; private set; }

    void Update()
    {
        TimeLeft = timeLimit - Time.timeSinceLevelLoad;
    }
}
