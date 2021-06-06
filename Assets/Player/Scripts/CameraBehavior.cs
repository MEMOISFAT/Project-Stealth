using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private Transform cam;
    private Transform player;
    private Vector3 direction;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        RotateAroundPlayer();
        
    }


    void RotateAroundPlayer()
    {
        Vector3 currentAngle = transform.eulerAngles;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        currentAngle = new Vector3(0f, Mathf.SmoothDampAngle(currentAngle.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime), 0f);
        //Debug.Log(currentAngle);
        transform.position = player.position;
        transform.eulerAngles = currentAngle;
    }
}
