using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRise : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRot = transform.rotation.eulerAngles;
        currentRot.x += 0.01f;
        Quaternion rot = Quaternion.Euler(currentRot);
        transform.rotation = rot;

    }
}