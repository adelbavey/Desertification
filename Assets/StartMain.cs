using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMain : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lightSource;
    void Start()
    {
        Vector3 currentRot = lightSource.transform.rotation.eulerAngles;
        Quaternion rot = Quaternion.Euler(-5,currentRot.y,currentRot.z);
        lightSource.transform.rotation = rot;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRot = lightSource.transform.rotation.eulerAngles;
        if(currentRot.x <= 30f || currentRot.x >= 350){
            currentRot.x += 0.05f;
            Quaternion rot = Quaternion.Euler(currentRot);
            lightSource.transform.rotation = rot;
        }else{
            Cursor.lockState = CursorLockMode.Confined;
        }
        

        
    }
}
