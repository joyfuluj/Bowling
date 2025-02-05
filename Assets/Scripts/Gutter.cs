using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider triggeredBody)
    {
        // First, get the rigidbody of the ball
        Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>();

        // store the velocity magnitude before resetting the veocity
        float velocityMagnitude =  ballRigidBody.linearVelocity.magnitude;

        // It is important to reset the linear AND angular velocity
        // This is because the ball is rotating on the ground when moving
        ballRigidBody.linearVelocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;

        // add force in the forward direction of the gutter
        // use the cached velocity magnitude to keep it a little realistic
        ballRigidBody.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
