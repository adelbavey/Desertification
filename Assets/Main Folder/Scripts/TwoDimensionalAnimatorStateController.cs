using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimensionalAnimatorStateController : MonoBehaviour
{

    Animator animator;
    float velocityX = 0.0f;
    float velocityY = 0.0f;
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

    bool isJumping;
    bool isFalling;

    Vector3 velocity;

    Vector3 rootMotion;

    public float stepDown;
    public float jumpDamp;
    /****/

    //Rigidbody
    //[SerializeField]
    //private Rigidbody playerBody;

    //Increase performance
    int VelocityZHash;
    int VelocityXHash;
    int VelocityYHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //playerBody = GetComponent<Rigidbody>();

        //Increase performance
        VelocityZHash = Animator.StringToHash("Velocity Z");
        VelocityYHash = Animator.StringToHash("Velocity Y");
        VelocityXHash = Animator.StringToHash("Velocity X");
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool backwardPressed = Input.GetKey(KeyCode.S);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        bool jumpPressed = Input.GetKey(KeyCode.Space);

        //Set current maxVelocity
        float currentMaxVelocity = runPressed ? maximumRunVelocity : maximumWalkVelocity;

        if (forwardPressed && velocityZ < currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * acceleration;
        }
        /*if (backwardPressed && velocityZ > -currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * acceleration;
        }*/

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


        //Jumping

        if (jumpPressed)
        {
            Jump();
        }




        animator.SetFloat(VelocityZHash, velocityZ);
        animator.SetFloat(VelocityXHash, velocityX);

    }


    void OnAnimatorMove()
    {
        rootMotion += animator.deltaPosition;


    }

    private void FixedUpdate()
    {

        if (animator)
        {
            controller.Move(rootMotion);
            rootMotion = Vector3.zero;

            //Camera follow mouse variables
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;



            //Debug.DrawLine(transform.position + dir, transform.position + dir*dir.magnitude,Color.red);
            
            if (dir.magnitude >= 0.0f)
            {

                //Allign the camera to the back of the character
                //Changed to 0 from dir.x since rotation was wrong direction
                float targetAngle = Mathf.Atan2(0, dir.z) * Mathf.Rad2Deg + followCamera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                
                Debug.DrawRay(transform.position + new Vector3(0,1,0), moveDir.normalized, Color.red, 1);

                if(animator.GetFloat(VelocityXHash) != 0){
                    Vector3 moveAmount = new Vector3(0,0,0);
                    //Z axis
                    moveAmount += moveDir;
                    //X Axis
                    moveAmount = moveAmount.normalized;
                    moveAmount *=  animator.GetFloat(VelocityZHash);
                    moveAmount += new Vector3(moveDir.z, moveDir.y, -moveDir.x).normalized * animator.GetFloat(VelocityXHash);
                    
                    
                    controller.Move(moveAmount * speed * Time.deltaTime);

                }else{
                    controller.Move(moveDir.normalized * animator.GetFloat(VelocityZHash) * speed * Time.deltaTime);
                }

            }

            //Side walking


        }



        if (isJumping)
        {//is inAir state
            velocity.y += gravity * Time.fixedDeltaTime;
            controller.Move(velocity * Time.fixedDeltaTime);
            isJumping = !controller.isGrounded;
            rootMotion = Vector3.zero;

        }
        else
        {//IsGrounded state
            controller.Move(rootMotion + Vector3.down * stepDown);
            rootMotion = Vector3.zero;
            animator.SetBool("isJumping", false);
            if (controller.isGrounded)
            {
                isJumping = true;
                velocity = animator.velocity * jumpDamp;
                velocity.y = 0;
            }
        }


    }

    void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            velocity = animator.velocity * jumpDamp;
            velocity.y = Mathf.Sqrt(2 * -gravity * jumpHeight);
            animator.SetBool("isJumping", true);
            //Test audio
            AkSoundEngine.PostEvent("stepSound", gameObject);   
            //
        }
    }

}
