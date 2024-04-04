using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentMovement : MonoBehaviour
{
    [SerializeField] private Transform trans;
    [SerializeField] private Transform playerTransform;
	[SerializeField] private Rigidbody rb;
	[SerializeField] private Transform target;
	[SerializeField] private OpponentTargetMovement targetLocation;
    [SerializeField] private Animator animator;
    [SerializeField] EnemyLauncher launchScript;


	private float maxSpeed;
	private float radiusOfSat;
    private bool canThrow = true;
    private bool reachedLocation = false;
    private float stop = 0;

	void Start () {
		maxSpeed = 3.5f;
		radiusOfSat = 1f;
	}
	
	// Update is called once per frame
	void Update () {
        stop -= Time.deltaTime; 

        // Calculate vector from character to target
        Vector3 towards = target.position - trans.position;
        Vector3 towardsPlayer = playerTransform.position - trans.position;

        // Determine if character needs to look at player or direction they are headed
        if(reachedLocation) {
            trans.rotation = Quaternion.LookRotation (towardsPlayer);
        } else {
            trans.rotation = Quaternion.LookRotation (towards);
        }

        // If we haven't reached the target yet
		if (stop < 0 && towards.magnitude > radiusOfSat) {
            reachedLocation = false;
		    // Normalize vector to get just the direction
			towards.Normalize ();
			towards *= maxSpeed;

			// Move character
			rb.velocity = towards;
		}
        // if player is at target location then stay there for 2 seconds and throw a ball
        // if(rb.velocity < noMovement) {
        else {
            coolDown();
            reachedLocation = true;

            if(canThrow) {
                animator.SetTrigger("throw");
                canThrow = false;
            }
        }



        //Debug.Log(stop);
        //Debug.Log(rb.velocity);

		
	}

    // Player is able to move and throw after every 2 seconds
    private void coolDown() {
        if(stop <= 0) {
            stop = 2;
            canThrow = true;
        }
    }

    public void OpponentThrow() {
        launchScript.Shoot();
    }

}
