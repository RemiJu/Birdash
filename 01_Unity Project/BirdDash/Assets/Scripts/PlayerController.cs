using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public HingeJoint BottomWheelHinge;
    private JointSpring BottomWheelSpring;
    public float acceleration;
    public float acceleration2;

    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    float verticalInputCheck;

    [Header("Jump")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    float targetRotation;

    public Rigidbody rb;

    [Header("Timer Check")]
    public Timer timer;

    public void Awake()
    {
        //rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;

        BottomWheelSpring = BottomWheelHinge.spring;
    }


    public void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);




        if (timer != null && timer.timesIUp == false && !PauseMenu.isPaused)
        {
            MyInput();
            SpeedControl();

        }
        else if (timer == null ){
            MyInput();
            SpeedControl();
        }
        
        //handle drag
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else { rb.drag = 0; }

    }

    public void FixedUpdate()
    {
        if (timer != null && timer.timesIUp == false)
        {
            MovePlayer();
        }
        else if (timer ==null) { MovePlayer(); }
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        verticalInput = Input.GetAxisRaw("Vertical");

        //when to jump

        if (Input.GetKey(jumpKey) && readyToJump && grounded) 
        { 
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        
        }
    
   }

    private void MovePlayer()
    {
        //calculate movement direction

        float horizontalMovement = rb.velocity.magnitude / moveSpeed * horizontalInput;

        

        if (verticalInput >= 0) {
            verticalInputCheck = verticalInput;
        }
        else if (verticalInput < 0) {
            verticalInputCheck = 0;
        }

        moveDirection = orientation.forward * verticalInputCheck /*+ orientation.right * horizontalMovement*/;

        //on ground
        if (grounded)
        {
            float inputRotationInfluence = (-horizontalInput + 1) / 2;

            float wheelZAngle = BottomWheelHinge.transform.rotation.eulerAngles.z;
            float wheelDirection = (wheelZAngle < 180) ? 1 : -1;

            float gravityRotationInfluence = (wheelZAngle < 180) ? BottomWheelHinge.transform.rotation.eulerAngles.z : 360 - BottomWheelHinge.transform.rotation.eulerAngles.z;
            gravityRotationInfluence *= wheelDirection;

            targetRotation += Mathf.Lerp(-90, 90, inputRotationInfluence) * Time.deltaTime * acceleration;
            targetRotation += gravityRotationInfluence * Time.deltaTime * acceleration;

            targetRotation = Mathf.Clamp(targetRotation, -90, 90);

            //Debug.Log(Mathf.Lerp(-90, 90, inputRotationInfluence));

            BottomWheelSpring.targetPosition += targetRotation * Time.deltaTime * acceleration2;
            BottomWheelSpring.targetPosition = Mathf.Clamp(BottomWheelSpring.targetPosition, -90, 90);

            BottomWheelHinge.spring = BottomWheelSpring;

            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        //in air
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }

       
    }

    private void SpeedControl() 
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if (flatVel.magnitude > moveSpeed) 
        { 
            Vector3 limitedVel = flatVel.normalized *moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        
        }
    }

    private void Jump() 
    {
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    
    }

    private void ResetJump() 
    { readyToJump = true; }
}