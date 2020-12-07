using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimensionalAnimatorStateController : MonoBehaviour
{

    Animator animator;
    float velocityX = 0.0f;
    float velocityZ = 0.0f;

    public float acceleration = 2.0f;
    public float deceleration = 2.0f;
    public float maximumWalkVelocity = 0.5f;
    public float maximumRunVelocity = 2.0f;

    public float speed = 1.0f;
    /****/
    public float rotationalSpeed = 10.0f;

    public Transform followCamera;

    public CharacterController controller;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public float jumpHeight;
    public float gravity = -9.81f;

    Vector3 rootMotion;
    bool isJumping;
    bool isFalling;
    /****/

    //Rigidbody
    //[SerializeField]
    //private Rigidbody playerBody;

    //Increase performance
    int VelocityZHash;
    int VelocityXHash;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //playerBody = GetComponent<Rigidbody>();

        //Increase performance
        VelocityZHash = Animator.StringToHash("Velocity Z");
        VelocityXHash = Animator.StringToHash("Velocity X");
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        //Set current maxVelocity
        float currentMaxVelocity = runPressed ? maximumRunVelocity : maximumWalkVelocity;

        if (forwardPressed && velocityZ < currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * acceleration;
        }
        if (leftPressed && velocityX > -currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * acceleration;
        }
        if (rightPressed && velocityX < currentMaxVelocity)
        {
            velocityX += Time.deltaTime * acceleration;
        }

        //Decrease velocityZ
        if (!forwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }

        //Resett
        if (!forwardPressed && velocityZ < 0.0f)
        {
            velocityZ = 0.0f;
        }


        if (!leftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * deceleration;
        }

        if (!rightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * deceleration;
        }

        if (!rightPressed && !leftPressed && velocityX != 0f && (velocityX > -0.05f && velocityX < 0.05f))
        {
            velocityX = 0.0f;
        }


        //Lock forward
        if (forwardPressed && runPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ = currentMaxVelocity;
        }
        //Decelerate to maximum walk velocity
        else if (forwardPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * deceleration;

            if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05))
            {
                velocityZ = currentMaxVelocity;
            }

        }
        //Round to the current max velocity if within offset
        else if (forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f))
        {
            velocityZ = currentMaxVelocity;
        }

        /***********************/

        //Lock Left
        if (leftPressed && runPressed && velocityX < -currentMaxVelocity)
        {
            velocityX = -currentMaxVelocity;
        }
        //Decelerate to maximum walk velocity
        else if (leftPressed && velocityX < -currentMaxVelocity)
        {
            velocityX += Time.deltaTime * deceleration;

            if (velocityX < -currentMaxVelocity && velocityX > (-currentMaxVelocity - 0.05))
            {
                velocityX = -currentMaxVelocity;
            }

        }
        //Round to the current max velocity if within offset
        else if (leftPressed && velocityX > -currentMaxVelocity && velocityX < (-currentMaxVelocity + 0.05f))
        {
            velocityX = -currentMaxVelocity;
        }

        /***********************/

        //Lock Right
        if (rightPressed && runPressed && velocityX > currentMaxVelocity)
        {
            velocityX = currentMaxVelocity;
        }
        //Decelerate to maximum walk velocity
        else if (rightPressed && velocityX > currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * deceleration;

            if (velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity + 0.05))
            {
                velocityX = currentMaxVelocity;
            }

        }
        //Round to the current max velocity if within offset
        else if (rightPressed && velocityX < currentMaxVelocity && velocityX > (currentMaxVelocity - 0.05f))
        {
            velocityX = currentMaxVelocity;
        }


        animator.SetFloat(VelocityZHash, velocityZ);
        animator.SetFloat(VelocityXHash, velocityX);

    }


    void OnAnimatorMove()
    {
        Animator animator = GetComponent<Animator>();

        if (animator)
        {

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;



            //Debug.DrawLine(transform.position + dir, transform.position + dir*dir.magnitude,Color.red);

            if (dir.magnitude >= 0.0f)
            {

                //Allign the camera to the back of the character
                float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + followCamera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * animator.GetFloat(VelocityZHash) * speed * Time.deltaTime);

            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }


        }
    }

    void Jump(){
        if(!isJumping){
            isJumping = true;
            
        }
    }

}
