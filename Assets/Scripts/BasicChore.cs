using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicChore : Chore
{
    [SerializeField] private float holdDuration;
    private float holdTimer;
    private bool inPlayerRange = false;
    private ChoreManager choreManager;
    public Animator anim;
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
        if (!completed && inPlayerRange && Input.GetKey(KeyCode.Space))
        {
            holdTimer += Time.deltaTime;
            if (anim != null) {
                anim.SetBool("Space_Held", true);
            }
            if (holdTimer > holdDuration)
            {
                if (anim != null) {
                    anim.SetBool("Space_Held", false);
                }
                completed = true;
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                choreManager.onChoreComplete();
            }
        }
        else
        {
            holdTimer = 0;
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
