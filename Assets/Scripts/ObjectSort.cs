using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSort : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool topLeft;
    private SpriteRenderer sprite;

    private Vector3 colliderBounds;
    private Camera cam;
    void Start()
    {
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        cam = Camera.main;
        colliderBounds = this.GetComponent<BoxCollider>().bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        sprite.sortingOrder = (int)(cam.WorldToScreenPoint(transform.position).y * -100);
    }


    void OnDrawGizmos()
    {
        
    }

}
