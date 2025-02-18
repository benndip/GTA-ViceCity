using UnityEngine;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;

    public Transform playerTransfrom;
    public Transform cameraPivot;

    private Vector3 cameraFollowVelocity = Vector3.zero;

    [Header("Camera Movement and Rotation")]
    public float camFollowSpeed = 0.1f;
    public float cameraLookSpeed = 0.1f;
    public float cameraPivotSpeed = 0.1f;
    public float lookAngle;
    public float pivotAngle;

    public float minimumPivotAngle = -30f;
    public float maximumPivotAngle = 30f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerTransfrom = FindFirstObjectByType<PlayerManager>().transform;
        inputManager = FindFirstObjectByType<InputManager>();
    }

    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
    }

    public void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, playerTransfrom.position, ref cameraFollowVelocity, camFollowSpeed);
        transform.position = targetPosition;
    }

    public void RotateCamera()
    {
        // Variable Declarations
        Vector3 rotation;
        Quaternion targetRotation;

        lookAngle += (inputManager.cameraInputX * cameraLookSpeed);
        pivotAngle -= (inputManager.cameraInputY * cameraPivotSpeed);

        //Restricting Camera Angle
        pivotAngle = Mathf.Clamp(pivotAngle, minimumPivotAngle, maximumPivotAngle);


        //Horizontal Movement
        rotation = Vector3.zero;
        rotation.y = lookAngle;
        targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        //Vertical Movement
        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;
                

    }
}
