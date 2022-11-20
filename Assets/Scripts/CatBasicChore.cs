using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBasicChore : Chore
{
    [SerializeField] private float holdDuration;
    [SerializeField] private  GameObject player;
    private float holdTimer;
    private bool inPlayerRange = false;
    private ChoreManager choreManager;
    public Animator anim;
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(.5f, .6f, .1f, 0.8f));

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
            if (anim != null)
            {
                anim.SetBool("Space_Held", true);
                player.SetActive(false);
                

            }
            if (holdTimer > holdDuration)
            {
                if (anim != null)
                {
                    anim.SetBool("Space_Held", false);
                    
                }
                completed = true;
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                choreManager.onChoreComplete();
                player.SetActive(true);
            }
        }
        else
        {
            holdTimer = 0;
            
            anim.SetBool("Space_Held", false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inPlayerRange = true;
            if (!completed)
            {
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(.7f, .9f, .1f, 0.8f));
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
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(.5f, .6f, .1f, 0.8f));
            }
        }
    }
}
