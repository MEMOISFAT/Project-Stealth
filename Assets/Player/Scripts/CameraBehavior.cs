using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Transform cam;
    public Transform player;
    //public Transform pivot;
    public Vector3 offset;
    Vector3 direction;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //pivot = GameObject.FindGameObjectWithTag("CameraPivot").transform;
        cam = Camera.main.transform;
        
        //offset = new Vector3(player.position.x + 1f, player.position.y, player.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //offset = Quaternion.AngleAxis(Input.GetAxisRaw("Mouse X") * turnSmoothTime, -Vector3.up) * offset;
        //transform.position = player.position + offset;

        //float angleY = Mathf.Asin(Vector3.Cross(cam.forward, player.forward).y) * Mathf.Rad2Deg;
        //offset = Quaternion.Euler(0f, angleY, 0f) * offset;
        //Debug.Log(angleY);

        //transform.position = player.position + offset;

        //Vector3 dir = player.position - cam.position;
        //float angle = Vector3.Dot(cam.forward, dir);
        //Debug.Log(angle);

        //Vector3 direction = (player.position - cam.position).normalized;
        //float angle = Vector3.Angle(direction, player.forward);
        //Debug.Log(angle);

        //offset = Quaternion.Euler(0f, angle, 0f) * offset;


        //transform.position = player.position;
        //float mouseX = Input.GetAxisRaw("Mouse X");
        //direction = new Vector3(mouseX, 0f, 0f).normalized;
        //float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        //float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSmoothTime);
        //float angle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, turnSmoothTime * Time.deltaTime);
        //Debug.Log(angle);
        //transform.rotation = Quaternion.Euler(0f, angle, 0f);

        //transform.position = player.position;
        //transform.LookAt(pivot.transform.position - pivot.transform.right);

        Vector3 currentAngle = transform.eulerAngles;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        currentAngle = new Vector3(0f, Mathf.SmoothDampAngle(currentAngle.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime), 0f);
        Debug.Log(currentAngle);
        transform.position = player.position;
        transform.eulerAngles = currentAngle;
    }


    void RotateAroundPlayer()
    {

        /*float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        direction = new Vector3(hAxis, 0f, vAxis).normalized;


        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.RotateAround(player.position, Vector3.up, angle);
                //Quaternion.Euler(0f, angle, 0f);

        }*/
    }
}
