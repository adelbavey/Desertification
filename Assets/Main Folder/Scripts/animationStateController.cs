using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{


    Animator animator;
    int isWalkingHash;
    int isRunningHash;

    float velocity = 0.0f;
    public float acceleration= 0.1f;
    public float deceleration= 0.1f;
    int VelocityHash;

    // Start is called before the first frame update
    void Start()
    {
        //Reference for animator
        animator = GetComponent<Animator>();

        //Increase performance
        VelocityHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void Update()
    {

        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        
        if (forwardPressed)
        {
            if(velocity < 1.0f){
                velocity += Time.deltaTime * acceleration;
            }
        }
        if (!forwardPressed)
        {
            if(velocity > 0.0f){
                velocity -= Time.deltaTime * deceleration;
            }
        }

        //Error case
        if (!forwardPressed && velocity < 0.0f){
            velocity = 0.0f;
        }
        
        animator.SetFloat(VelocityHash, velocity);

    }










/*
    Animator animator;
    int isWalkingHash;
    int isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        
        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        //Walking to running 
        if (!isRunning && (forwardPressed && runPressed))
        {
            animator.SetBool(isRunningHash, true);
        }
         if (isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }
    }*/
}
