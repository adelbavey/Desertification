using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowShit : MonoBehaviour
{
    public float growSize = 0.05f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.localScale;
        temp.x += growSize;
        temp.y += growSize;
        temp.z += growSize;
        transform.localScale = temp; 
    }
}
