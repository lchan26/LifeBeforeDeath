using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSort : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer sprite;
    private Camera cam;
    void Start()
    {
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       sprite.sortingOrder = (int)(cam.WorldToScreenPoint(transform.position).y * -100);   
    }

}
