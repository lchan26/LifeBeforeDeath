using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemySprite : MonoBehaviour
{
    [SerializeField]
    Eyes enemyEyes;
    private GameObject internalEnemy;
    private int currentDir = 3;
    public Animator anim;

    private Vector3 prevPos;
    private Vector3 currPos;

    // Start is called before the first frame update
    void Start()
    {
        internalEnemy = GameObject.Find("Enemy");
        prevPos = internalEnemy.transform.position;
        currPos = internalEnemy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = internalEnemy.transform.position;
        currPos = internalEnemy.transform.position;
        List<float> dotProducts = new List<float>();
        // Index 0 is up, 1 is back, 2 is right, 3 is left
        //print(enemyEyes.MoveDirection);
        Vector3 direction = (currPos - prevPos).normalized;
        dotProducts.Add(Vector3.Dot(direction, Vector3.left));
        dotProducts.Add(Vector3.Dot(direction, Vector3.right));
        dotProducts.Add(Vector3.Dot(direction, Vector3.forward));
        dotProducts.Add(Vector3.Dot(direction, Vector3.back));

        float max_dist = Mathf.NegativeInfinity;
        for (int i = 0; i < 4; i++) {
            if (dotProducts[i] > max_dist) {
                max_dist = dotProducts[i];
                currentDir = i;
            }
        }
        // float angle = Vector3.Angle(transform.forward, enemyEyes.MoveDirection);

        // if (angle >= 0 && angle < 90) {
        //     currentDir = 1;
        // }

        // else if (angle >= 90 && angle < 180) {
        //     currentDir = 2;
        // }

        // else if (angle >= 180 && angle < 270) {
        //     currentDir = 0;
        // }

        // else if (angle >= 270 && angle < 360) {
        //     currentDir = 3;
        // }

        // print(angle);
        //float maxDotProduct = Mathf.Max(dotProductUp, dotProductDown, dotProductRight, dotProductLeft);
        // if (currentDir != dir) {
        //     directionChanged = true;
        // }
        
        // print(directionChanged);

        // if (dir == "Up" && directionChanged) {
        //     anim.SetBool("Up", true);
        //     anim.SetBool("Down", false);
        //     anim.SetBool("Right", false);
        //     anim.SetBool("Left", false);
        //     currentDir = "Up";
        //     directionChanged = false;
        // }
        // else if (dir == "Down" && directionChanged) {
        //     anim.SetBool("Up", false);
        //     anim.SetBool("Down", true);
        //     anim.SetBool("Right", false);
        //     anim.SetBool("Left", false);
        //     currentDir = "Down";
        //     directionChanged = false;
        // }
        // else if (dir == "Right" && directionChanged) {
        //     anim.SetBool("Up", false);
        //     anim.SetBool("Down", false);
        //     anim.SetBool("Right", true);
        //     anim.SetBool("Left", false);
        //     currentDir = "Right";
        //     directionChanged = false;
        // }
        // else if (dir == "Left" && directionChanged) {
        //     anim.SetBool("Up", false);
        //     anim.SetBool("Down", false);
        //     anim.SetBool("Right", false);
        //     anim.SetBool("Left", true);
        //     currentDir = "Left";
        //     directionChanged = false;
        // }

        print(currentDir);
        if (currentDir == 0)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Walk_Up"))
            {
                anim.SetTrigger("Up");
            }
        }
        else if (currentDir == 1)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Walk_Down"))
            {
                anim.SetTrigger("Down");
            }
        }
        else if (currentDir == 2)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Walk_Right"))
            {
                anim.SetTrigger("Right");
            }
        }
        else if (currentDir == 3)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Walk_Left"))
            {
                anim.SetTrigger("Left");
            }
        }
        prevPos = transform.position = internalEnemy.transform.position;
    }
}
