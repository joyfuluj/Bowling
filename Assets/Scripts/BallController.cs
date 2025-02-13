using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform launchIndicator;

    private bool isBallLaunched;
    [SerializeField] private InputManager inputManager;

    private Rigidbody ballRB;
    void Start()
    {
        //Grabbing a reference to RigidBody
        ballRB = GetComponent<Rigidbody>();

        // Add a listener to the OnSpacePressed event.
        // When the space key is pressed the
        // LaunchBall method will be called.
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;
    }

private void Update(){
    Debug.DrawRay(transform.position, launchIndicator.forward, Color.green);
}

    private void LaunchBall()
    {
        // if(isBallLaunched) return;

        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;
        Vector3 launchForce = launchIndicator.forward * force;
        launchForce = new Vector3(0, 0, launchForce.z);
        Debug.Log($"Applying force: {launchForce}");
        ballRB.AddForce(launchForce, ForceMode.Impulse);

        launchIndicator.gameObject.SetActive(false);
    }
}
