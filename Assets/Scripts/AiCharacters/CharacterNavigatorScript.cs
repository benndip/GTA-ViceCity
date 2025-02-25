using UnityEngine;

public class CharacterNavigatorScript : MonoBehaviour
{
    [Header("Character Info")]

    public float movingSpeed = 0f;
    public float turningSpeed = 300f;
    public float stopSpeed = 1f;

    [Header("Destination Variable")]
    public Vector3 destination;
    public bool destinationReached;
    public Animator animator;
    private float waypointTimeout = 30f;
    public float currentTimeout = 0f;

    void Update()
    {
        Walk();
    }

    private void Walk()
    {
        if(Vector3.Distance(transform.position, destination) > 0.0f)
        {
            Vector3 direction = destination - transform.position;
            direction.y = 0;
            float destinationDistance = direction.magnitude;
            if(destinationDistance >= stopSpeed)
            {
                destinationReached = false;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), turningSpeed * Time.deltaTime);
                transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);
            }
            else
            {
                destinationReached = true;
            }
        }
    }

    public void LocateDestination(Vector3 destination)
    {
        this.destination = destination;
        destinationReached = false;
        currentTimeout = 0f;
    }
}
