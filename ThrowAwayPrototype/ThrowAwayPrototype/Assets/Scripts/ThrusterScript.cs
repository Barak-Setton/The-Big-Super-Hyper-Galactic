using UnityEngine;
using System.Collections;

public class ThrusterScript : MonoBehaviour {

    public float thrusterStrength;
    public float thrusterDistance;
    public Transform[] thrusters;

    private Rigidbody carRigidbody;

    void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }
	// Use this for initialization
	void FixedUpdate () {
        RaycastHit hit;

        foreach(Transform thruster in thrusters)
        {
            Vector3 downwardForce;
            float distancePercentage;

            if (Physics.Raycast (thruster.position, thruster.up * -1, out hit, thrusterDistance))
            {
                // thruster within thrusterDistance to the ground (how far away?)
                distancePercentage = 1 - (hit.distance / thrusterDistance);

                // calculate how much force to push:
                downwardForce = (transform.up * thrusterStrength * distancePercentage);

                // Correct the force for mass of the car and deltatime:
                downwardForce = downwardForce * Time.deltaTime * carRigidbody.mass;

                // Apply the force where the thrust is:
                carRigidbody.AddForceAtPosition(downwardForce, thruster.position);

            }
        }
	}
}
