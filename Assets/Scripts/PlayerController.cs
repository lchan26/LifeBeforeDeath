using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 5;

    [SerializeField]
    private Collider botStairsCollider;
    [SerializeField]
    private Collider topStairsCollider;

    private bool inBotStair = false;
    private bool inTopStair = false;
    private bool isBeingSentUp = false;
    private bool isBeingSentDown = false;

    private Vector3 botStairsPos;
    private Vector3 topStairsPos;

    private void Start()
    {
        botStairsPos = botStairsCollider.bounds.center;
        topStairsPos = topStairsCollider.bounds.center;
        botStairsPos.y = 0;
        topStairsPos.y = 0;
    }

    void Update()
    {
        if (isBeingSentUp)
        {
            GetComponent<Rigidbody>().isKinematic = true;

            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, topStairsPos, step);
            if (transform.position == topStairsPos)
            {
                isBeingSentUp = false;
                GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        else if (isBeingSentDown)
        {
            GetComponent<Rigidbody>().isKinematic = true;

            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, botStairsPos, step);
            if (transform.position == botStairsPos)
            {
                isBeingSentDown = false;
                GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        else // normal movement case
        {
            Vector3 dir = Vector3.zero;

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
            {
                // move up
                dir += Vector3.left;
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
            {
                // move down
                dir += Vector3.right;
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
            {
                // move left
                dir += Vector3.back;

                // handle stairs movement
                if (inTopStair) isBeingSentDown = true;
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
            {
                // move right
                dir += Vector3.forward;

                // handle stairs movement
                if (inBotStair) isBeingSentUp = true;
            }
        
            gameObject.GetComponent<Rigidbody>().velocity = speed * dir.normalized;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StairBottom")) inBotStair = true;
        else if (other.CompareTag("StairTop")) inTopStair = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("StairBottom")) inBotStair = false;
        else if (other.CompareTag("StairTop")) inTopStair = false;
    }
}
