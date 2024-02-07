using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // input fields
    private ThirdPersonActionsAsset playerActionsAsset;
    private InputAction move;

    // movement fields
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float movementForce = 1f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float maxSpeed = 5f;
    private Vector3 forceDirection = Vector3.zero;

    [SerializeField] private Camera mainCamera;


    // Initialize fields before application starts so that ThirdPersonActionsAsset can be intialized
    private void Awake() {
        playerActionsAsset = new ThirdPersonActionsAsset();
        move = playerActionsAsset.Player.Move;
    }

    #region Character Movement
    // Move character based on input
    private void FixedUpdate() {
        // Get movement direction (relative to the camera)
        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(mainCamera) * movementForce;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(mainCamera) * movementForce;

        // Make character move
        playerRigidbody.AddForce(forceDirection, ForceMode.Impulse);
        // When no control input occuring it will stop moving the character
        forceDirection = Vector3.zero;

        // Make sure player does not exceed max speed
        Vector3 horizontalVelocity = playerRigidbody.velocity;
        horizontalVelocity.y = 0; // Only checking x velocity (not y)
        if(horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed) {
            // set velocity to max velocity if too fast
            playerRigidbody.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * playerRigidbody.velocity.y;
        }

        // Rotate player to look in direction of movement
        PlayerRotation();
    }

    private void OnEnable() {
        playerActionsAsset.Player.Enable();
    }

    private void OnDisable() {
        playerActionsAsset.Player.Disable();
    }
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
    #endregion

    // Look at the direction player is moving
    private void PlayerRotation() {
        Vector3 direction = playerRigidbody.velocity;

        // Don't have player look up or down
        direction.y = 0f;

        // Check if player is recieving input and we are moving then change look direction
        if(move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f) {
            // TODO: Change to Slerp
            playerRigidbody.rotation = Quaternion.LookRotation(direction, Vector3.up);
        } else {
            // stop rotating
            playerRigidbody.angularVelocity = Vector3.zero;
        }
    }
}
