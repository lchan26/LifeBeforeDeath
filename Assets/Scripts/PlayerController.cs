using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 5;
    [SerializeField]
    private bool inBotStair = false;
    [SerializeField]
    private bool inTopStair = false;
    [SerializeField]
    private bool isBeingSent = false;

    [SerializeField]
    private Collider botStairsCollider;
    [SerializeField]
    private Collider topStairsCollider;

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
            if (inTopStair) SendDownstairs();
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            // move right
            dir += Vector3.forward;

            // handle stairs movement
            if (inBotStair) SendUpstairs();
        }

        if (!isBeingSent)
        {
            gameObject.GetComponent<Rigidbody>().velocity = speed * dir.normalized;
        }
    }

    void SendUpstairs()
    {
        inTopStair = false;
        isBeingSent = true;

        //transform.position = topStairsPos;
    }

    IEnumerator InterpolateThroughStairs(Vector3 targetPos)
    {
        float step = speed * Time.deltaTime;
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, topStairsPos, step);
            if (inTopStair)
            {
                isBeingSent = false;
                break;
            }
            yield return null;
        }
    }

    void SendDownstairs()
    {
        inBotStair = false;
        isBeingSent = true;

        transform.position = botStairsPos;

        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, botStairsPos, step);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StairBottom"))
        {
            isBeingSent = false;
            inBotStair = true;
        }

        else if (other.CompareTag("StairTop"))
        {
            isBeingSent = false;
            inTopStair = true;
        }
    }
}
