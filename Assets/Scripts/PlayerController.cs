using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    private bool up = true;
    private bool down = true;
    private bool left = true;
    private bool right = true;
    enum direction {
        up,
        down,
        left,
        right
    }
    private direction dir = direction.up;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // TODO change the arbitrary heirarchy of these if statement movement things

        if (Input.GetKey(KeyCode.UpArrow) && up == true)
        {
            // move up
            transform.position += Vector3.left * speed * Time.deltaTime;
            dir = direction.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && down == true)
        {
            // move down
            transform.position += Vector3.right * speed * Time.deltaTime;
            dir = direction.down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && left == true)
        {
            // move left
            transform.position += Vector3.back * speed * Time.deltaTime;
            dir = direction.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && right == true)
        {
            // move right
            transform.position += Vector3.forward * speed * Time.deltaTime;
            dir = direction.right;
        }
    }

    void OnTriggerEnter(Collider other) {
        switch(other.gameObject.tag){
            case "Up Wall": up = false; break;
            case "Down Wall": down = false; break;
            case "Left Wall": left = false; break;
            default: right = false; break; 
        }
    }

    void OnTriggerExit(Collider other) {
        switch(other.gameObject.tag){
            case "Up Wall": up = true; break;
            case "Down Wall": down = true; break;
            case "Left Wall": left = true; break;
            default: right = true; break; 
        }
    }
}
