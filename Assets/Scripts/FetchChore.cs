using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchChore : Chore
{
    [SerializeField] private GameObject item;
    private bool inPlayerRange = false;
    public bool inItemRange = false;
    private bool hasItem = false;
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
        if (!completed && hasItem && inPlayerRange && Input.GetKey(KeyCode.Space))
        {
            completed = true;
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            choreManager.onChoreComplete();
        }

        if (inItemRange && Input.GetKeyDown(KeyCode.Space))
        {
            hasItem = true;
            Destroy(item);
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
        if (other.gameObject.Equals(item))
        {
            inItemRange = true;
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
        if (other.gameObject.Equals(item))
        {
            inItemRange = false;
        }
    }
}
