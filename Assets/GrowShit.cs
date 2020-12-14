using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowShit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.localScale;
        temp.x += 0.05f;
        temp.y += 0.05f;
        temp.z += 0.05f;
        transform.localScale = temp; 
    }
}
