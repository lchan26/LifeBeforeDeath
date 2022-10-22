using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chore : MonoBehaviour
{
    [HideInInspector] public bool completed = false;

    private bool inPlayerRange = false;

    private ChoreManager choreManager;
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

        choreManager = FindObjectOfType<ChoreManager>().GetComponent<ChoreManager>();
        if (choreManager.Equals(null))
        {
            Debug.Log("ChoreManager not found in scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!completed && inPlayerRange && Input.GetKeyDown(KeyCode.Space))
        {
            completed = true;
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            choreManager.onChoreComplete();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inPlayerRange = true;
            if (!completed)
            {
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inPlayerRange = false;
            if (!completed)
            {
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }
        }
    }
}
