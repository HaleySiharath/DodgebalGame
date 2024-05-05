using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   #region : Fields
    [SerializeField] Camera mainCamera;

    // Player action asset
    private PlayerInput playerInputActionAsset;
    private InputAction movement;
    [SerializeField] Animator animator;
    [SerializeField] Launcher launchScript;

    // Player assets
    [SerializeField] private Rigidbody playerRigidbody;


    // Movement fields
    [SerializeField] private float walkSpeed = 2.5f;
    [SerializeField] private float sprintSpeed = 5f;
    [SerializeField] private float maxWalkSpeed = 2.5f;
    [SerializeField] private float maxSprintSpeed = 5f;
    private float maxSpeed = 5f;
    private float movementForce;
    private Vector3 forceDirection = Vector3.zero;
    private bool isSprinting = false;
    private bool isMoving = false;
    #endregion

    #region Enabling/Disabling player controls
    private void Awake() {
        playerInputActionAsset = new PlayerInput();
    }

    private void OnEnable() {
        movement = playerInputActionAsset.Dodgeball.MovementPressed;
        playerInputActionAsset.Dodgeball.Enable();  
    }

    private void OnDisable() {
        playerInputActionAsset.Dodgeball.Disable();  
    }
    #endregion

    private void FixedUpdate() {
        // sprinting value
        if(isSprinting && isMoving) {
            movementForce = sprintSpeed;
            maxSpeed = maxSprintSpeed;
        }
        // walking value
        else if(isMoving) {
            movementForce = walkSpeed;
            maxSpeed = maxWalkSpeed;
        }
        else {
            movementForce = 0f;
        }

        // Debug.Log(movementForce);
        forceDirection += movement.ReadValue<Vector2>().x * GetCameraRight(mainCamera) * movementForce;
        forceDirection += movement.ReadValue<Vector2>().y * GetCameraForward(mainCamera) * movementForce;

        // Make character move
        playerRigidbody.AddForce(forceDirection, ForceMode.Impulse);
        // When no control input occuring it will stop moving the character
        forceDirection = Vector3.zero;

        // Set limit to horizontal speed
        Vector3 horizontalVelocity = playerRigidbody.velocity;
        horizontalVelocity.y = 0;
        if(horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed) {
            playerRigidbody.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * playerRigidbody.velocity.y;
        }

        LookAt();
    }

    #region Rotation/Movement relative to camera


    /* Gets the projection of forward and right relative to camera 
        so player can use calculations to move on the horizontal plane
        TDLR: get the right and forward position of camera without
        tilt/angle offset  */

    private Vector3 GetCameraRight(Camera mainCamera) {
        Vector3 right = mainCamera.transform.right;
        right.y = 0;
        return right.normalized; 
    }
    private Vector3 GetCameraForward(Camera mainCamera) {
        Vector3 forward = mainCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }
  
    private void LookAt() {
        Vector3 direction = playerRigidbody.velocity;
        direction.y = 0f;

        // Movement input from player and we are moving
        if(movement.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f) {
            this.playerRigidbody.rotation = Quaternion.LookRotation(direction, Vector3.up);
        } else {
            playerRigidbody.angularVelocity = Vector3.zero;
        }
    }
    #endregion

    #region : Activate/deactivate movement values
    private void OnSprintPressed() {
        isSprinting = true;
    }

    private void OnSprintReleased() {
        isSprinting = false;
    }

    private void OnMovementPressed() {
        isMoving = true;
    }

    private void OnMovementReleased() {
        isMoving = false;
    }
    #endregion


    private void OnThrow() {
        animator.SetTrigger("throw");
    }

    public void PlayerThrow() {
        //StartCoroutine(launchScript.Shoot());
        if(SceneManager.GetActiveScene ().name == "DodgeballTestScene") {
            launchScript.Shoot();
        }
    }
}