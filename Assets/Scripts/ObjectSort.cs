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
        //float minX = col.bounds.center.x - col.bounds.size.x / 2;
        //float maxX = col.bounds.center.x + col.bounds.size.x / 2;
        //float minZ = col.bounds.center.z - col.bounds.size.z / 2;
        //float maxZ = col.bounds.center.z - col.bounds.size.z / 2;

        sprite.sortingOrder = (int)(cam.WorldToScreenPoint(transform.position).y * -100);   
    }

}
