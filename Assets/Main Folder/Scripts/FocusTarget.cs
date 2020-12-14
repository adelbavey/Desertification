using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public Cinemachine.CinemachineVirtualCameraBase c_VirtualCamera;
    [SerializeField] Transform target;
    [SerializeField] Transform character;
    Camera m_MainCamera;



    //public Camera m_TartgetCamera;
    private void Awake()
    {
        //c_VirtualCamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }
    private void Start()
    {
        
        //c_VirtualCamera.Follow = target.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(m_MainCamera.transform.position);
        c_VirtualCamera.OnTransitionFromCamera(c_VirtualCamera,Vector3.up, Time.deltaTime);
        
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(m_MainCamera.transform.position);
        c_VirtualCamera.LookAt = character.transform;
        
    }

}
