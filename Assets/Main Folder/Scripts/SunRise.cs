using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRise : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lightSource;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRot = lightSource.transform.rotation.eulerAngles;
        Debug.Log(currentRot);
        if(currentRot.x <= 25.0f || currentRot.x > 335){
            currentRot.x -= 0.05f;
        }
        

        Quaternion rot = Quaternion.Euler(currentRot);
        lightSource.transform.rotation = rot;

    }
}