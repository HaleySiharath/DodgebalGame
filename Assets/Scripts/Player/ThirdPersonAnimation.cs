using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float maxSpeed = 5f;
    

    // Change animation based on the players speed
    void Update()
    {
        animator.SetFloat("speed", playerRigidbody.velocity.magnitude / maxSpeed);
    }
}
