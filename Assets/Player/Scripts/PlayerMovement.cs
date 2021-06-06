using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cam;

    public float pSpeed = 10f;
    public float maxSpeed = 5;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    Vector3 direction;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpPower;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        Jump();
    }

    void Move()
    {
        float speed = Mathf.Abs(rb.velocity.magnitude);
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        direction = new Vector3(hAxis, 0f, vAxis).normalized;


        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.AddForce(moveDir.normalized * pSpeed * Time.deltaTime, ForceMode.Impulse);
            Debug.Log(rb.velocity);
            
            if (speed > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
        }
    }

    void Jump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0, jumpPower, 0) * 50, ForceMode.Acceleration);
            isGrounded = false;
        }

    }

}
