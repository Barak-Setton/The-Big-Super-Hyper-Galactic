using UnityEngine;
using System.Collections;

public class HovercarController : MonoBehaviour {

    public bool toHeigh;

    public float drag;

    public float acceleration;
    public float rotationRate;

    public float turnRotationAngle;
    public float turnRotationSeekSpeed;

    private float rotationVelocity;
    private float groundAngleVelocity;

    private Rigidbody carRigidbody;


    // Use this for initialization
    void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        // check if we are touching the ground:
        if (Physics.Raycast(transform.position, transform.up * -1, 10f))
        {
            toHeigh = false;

            // we are on the ground; enable the accelerator and increase drag:
            carRigidbody.drag = drag;

            // calculate forward force:
            Vector3 forwardForce = transform.forward * acceleration * Input.GetAxis("Vertical");


            // correct force for deltatime and vehicle mass:
            forwardForce = forwardForce * Time.deltaTime * carRigidbody.mass;
            carRigidbody.AddForce(forwardForce);
        }
        else
        {
            toHeigh = true;
            // we aren't on the ground and dont want to just halt in mid-air: reduce drag:
            carRigidbody.drag = 1.5f; // NEED TO FIGURE THIS OUT SO IT DOESNT DRIFT FOR REALLY LONG
        }
    }
}
