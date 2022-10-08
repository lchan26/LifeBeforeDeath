using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    // private bool up = true;
    // private bool down = true;
    // private bool left = true;
    // private bool right = true;
    public bool up = true;
    public bool down = true;
    public bool left = true;
    public bool right = true;

    Vector3 upVector = new Vector3(-1, 0, 1);
    Vector3 rightVector = new Vector3(1, 0, 1);
    Vector3 downVector = new Vector3(1, 0, -1);
    Vector3 leftVector = new Vector3(-1, 0, -1);
    // Vector3 upVector = Vector3.forward;
    // Vector3 rightVector = Vector3.right;
    // Vector3 downVector = Vector3.back;
    // Vector3 leftVector = Vector3.left;

    Ray ray;
    
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
            ray = new Ray(transform.position, upVector);
            transform.position += Vector3.left * speed * Time.deltaTime;
            dir = direction.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && down == true)
        {
            // move down
            ray = new Ray(transform.position, downVector);
            transform.position += Vector3.right * speed * Time.deltaTime;
            dir = direction.down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && left == true)
        {
            // move left
            ray = new Ray(transform.position, leftVector);
            transform.position += Vector3.back * speed * Time.deltaTime;
            dir = direction.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && right == true)
        {
            // move right
            ray = new Ray(transform.position, rightVector);
            transform.position += Vector3.forward * speed * Time.deltaTime;
            dir = direction.right;
        }
    }

    void OnTriggerEnter(Collider other) {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            Vector3 localPoint = hit.transform.InverseTransformPoint(hit.point);
            Vector3 localDir = localPoint.normalized;
            float upDot = Vector3.Dot(localDir, upVector);
            float rightDot = Vector3.Dot(localDir, rightVector);
            float downDot = Vector3.Dot(localDir, downVector);
            float leftDot = Vector3.Dot(localDir, leftVector);
            print("LocalDir: " + localDir);
            print("Up: " + upDot);
            print("Right: " + rightDot);
            print("Down: " + downDot);
            print("Left: " + leftDot);
            if(upDot < -0.5) {
                up = false;
            }
            if(rightDot < -0.5) {
                right = false;
            }
            if(downDot < -0.5) {
                down = false;
            }
            if(leftDot < -0.5) {
                left = false;
            }
        }  
        // switch(other.gameObject.tag){
        //     case "Up Wall": up = false; break;
        //     case "Down Wall": down = false; break;
        //     case "Left Wall": left = false; break;
        //     default: right = false; break; 
        // }
    }

    void OnTriggerExit(Collider other) {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            Vector3 localPoint = hit.transform.InverseTransformPoint(hit.point);
            Vector3 localDir = localPoint.normalized;
            float upDot = Vector3.Dot(localDir, upVector);
            float rightDot = Vector3.Dot(localDir, rightVector);
            float downDot = Vector3.Dot(localDir, downVector);
            float leftDot = Vector3.Dot(localDir, leftVector);
            if(upDot > 0.5) {
                up = true;
            }
            if(rightDot > 0.5) {
                right = true;
            }
            if(downDot > 0.5) {
                down = true;
            }
            if(leftDot > 0.5) {
                left = true;
            }
        }  

        // switch(other.gameObject.tag){
        //     case "Up Wall": up = true; break;
        //     case "Down Wall": down = true; break;
        //     case "Left Wall": left = true; break;
        //     default: right = true; break; 
        // }
    }
}
