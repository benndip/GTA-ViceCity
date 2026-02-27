using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    AnimatorManager animatorManager;
    PlayerMovement playerMovement;
    CameraPositionManager cameraPositionManager;


    public float moveAmount;
    private Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;
    private Vector2 cameraInput;
    public float cameraInputX;
    public float cameraInputY;

    [Header("Input Button Flag")]
    public bool bInput;
    public bool jumpInput;
    public bool interactInput;
    public bool previousInput;
    public bool buyInput;
    public bool nextInput;

    void Awake()
    {
        animatorManager = FindFirstObjectByType<AnimatorManager>();
        cameraPositionManager = FindFirstObjectByType<CameraPositionManager>();
        playerMovement = GetComponent<PlayerMovement>();

    }

    void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.CameraMovement.performed += i => cameraInput = i.ReadValue<Vector2>();
            playerControls.PlayerActions.B.performed += i => bInput = true;
            playerControls.PlayerActions.B.canceled += i => bInput = false;
            playerControls.PlayerActions.Jump.performed += i => jumpInput = true;
            playerControls.PlayerActions.Interact.performed += i => interactInput = true;
            playerControls.PlayerActions.Next.performed += i => nextInput = true;
            playerControls.PlayerActions.Previous.performed += i => previousInput = true;
            playerControls.PlayerActions.Buy.performed += i => buyInput = false;

        }

        playerControls.Enable();
    }

    void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleSprintingInput();
        HandleJumpingInput();
        HandleInteractInput();
        HandleNextInput();
        HandlePreviousInput();
        HandleBuyInput();
    }

    private void HandleMovementInput()
    {

        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimValues(0, moveAmount, playerMovement.isSprinting);

    }

    private void HandleSprintingInput()
    {
        if (bInput && moveAmount > 0.5f)
        {
            playerMovement.isSprinting = true;
        }
        else
        {
            playerMovement.isSprinting = false;
        }
    }

    private void HandleJumpingInput()
    {
        if (jumpInput)
        {
            jumpInput = false;
            playerMovement.isJumping = true;
            playerMovement.HandleJumping();
        }
    }

    private void HandleInteractInput()
    {
        if (interactInput)
        {
            interactInput = false;
        }
    }

    private void HandlePreviousInput()
    {
        if (previousInput)
        {
            cameraPositionManager.PreviousCameraPosition();
            previousInput = false;
        }
    }

    private void HandleNextInput()
    {
        if (nextInput)
        {
            cameraPositionManager.NextCameraPosition();
            nextInput = false;
        }
    }

    private void HandleBuyInput()
    {
        if (buyInput)
        {
            cameraPositionManager.BuyItem();
            buyInput = false;
        }
    }
}
