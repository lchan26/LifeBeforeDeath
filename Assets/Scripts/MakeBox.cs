using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBox : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRender;

    [SerializeField]
    private BoxCollider box;
    
    private float c;

    [SerializeField]
    private float x = 0.5f; // between 0 and 1

    // TODO fix
    private float h = 6.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //c = spriteRender.size.x;
        c = spriteRender.sprite.bounds.size.x;
        float a = Mathf.Sqrt(2) * (c * x);
        float b = Mathf.Sqrt(2) * (c - (c * x));

        box.size = new Vector3(a, h, b);
    }
}
