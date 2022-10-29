using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 5;
    public bool inBotStair = false;
    public bool inTopStair = false;

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
        {
            // move up
            dir += Vector3.left;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
        {
            // move left
            dir += Vector3.back;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            // move down
            dir += Vector3.right;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            // move right
            dir += Vector3.forward;
        }

        gameObject.GetComponent<Rigidbody>().velocity = speed * dir.normalized;

        if (inBotStair == true) 
        {
            // Vector3 currPos = transform.position;
            // Vector3 moveTo = new Vector3(-19.1170f, 0.0f, 4.3f);
            // // Vector3 translation = t
            // // transform.Translate()
            float step = speed * Time.deltaTime;
            // Vector3 moveTo1 = new Vector3(-19.1170f, 0.0f, 4.3f);
            // if (transform.position != moveTo1)
            // {
            //     transform.position = Vector3.MoveTowards(transform.position, moveTo1, step);   
            // }
            // transform.position = Vector3.MoveTowards(transform.position, moveTo, step);
            Vector3 moveTo = new Vector3(-22.857f, 0.0f, 13.051f);
            transform.position = Vector3.MoveTowards(transform.position, moveTo, step);
        }
        if (inTopStair == true) 
        {
            // Vector3 currPos = transform.position;
            // Vector3 moveTo = new Vector3(-19.1170f, 0.0f, 4.3f);
            // // Vector3 translation = t
            // // transform.Translate()
            float step = speed * Time.deltaTime;
            // Vector3 moveTo1 = new Vector3(-22.590f, 0.0f, 14.172f);
            // if (transform.position != moveTo1)
            // {
            //     transform.position = Vector3.MoveTowards(transform.position, moveTo1, step);   
            // }
            // transform.position = Vector3.MoveTowards(transform.position, moveTo, step);
            Vector3 moveTo = new Vector3(-19.398f, 0.0f, 4.944f);
            transform.position = Vector3.MoveTowards(transform.position, moveTo, step);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StairBottom"))
        {
            if (inTopStair == true)
            {
                inTopStair = false;
            }
            else
            {
                inBotStair = true;
            }
        }

        else if (other.CompareTag("StairTop"))
        {
            if (inBotStair == true)
            {
                inBotStair = false;
            }
            else
            {
                inTopStair = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // if (other.CompareTag("StairBottom"))
        // {
        //     inBotStair = false;
        // }

        // if (other.CompareTag("StairTop"))
        // {
        //     inTopStair = false;
        // }
    }
}
