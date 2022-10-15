using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSort : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool isTopLeft;
    private SpriteRenderer sprite;

    private Collider col;
    private Camera cam;
    void Start()
    {
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        cam = Camera.main;
        col = this.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 topLeft = new Vector3(col.bounds.center.x - col.bounds.size.x / 2, 0, col.bounds.center.z + col.bounds.size.z / 2);
        Vector3 bottomRight = new Vector3(col.bounds.center.x + col.bounds.size.x / 2, 0, col.bounds.center.z + col.bounds.size.z / 2);

        if (isTopLeft)
        {
            sprite.sortingOrder = (int)(cam.WorldToScreenPoint(topLeft).y * -100);
        }
        else
        {
            sprite.sortingOrder = (int)(cam.WorldToScreenPoint(bottomRight).y * -100);
        }
    }


    void OnDrawGizmos()
    {
        Vector3 topLeft = new Vector3(col.bounds.center.x - col.bounds.size.x / 2, 0, col.bounds.center.z + col.bounds.size.z / 2);
        Gizmos.DrawSphere(topLeft, .1f);
    }

}
