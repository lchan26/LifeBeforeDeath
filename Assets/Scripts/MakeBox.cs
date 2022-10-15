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

    [Range(0.0f, 1.0f)]
    [SerializeField]
    private float sideLength = 0.5f; // between 0 and 1

    [SerializeField]
    private float height = 6.5f;

    // Start is called before the first frame update
    void Start()
    {
        UpdateBoxCollider();
    }

    private void OnValidate()
    {
        UpdateBoxCollider();
    }

    void UpdateBoxCollider()
    {
        c = spriteRender.sprite.bounds.size.x;
        float a = Mathf.Sqrt(2) * (c * sideLength);
        float b = Mathf.Sqrt(2) * (c - (c * sideLength));

        box.size = new Vector3(a, height, b);
    }
}
