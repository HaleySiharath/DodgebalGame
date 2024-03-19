using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentMovement : MonoBehaviour
{
    
	[SerializeField] private Transform trans;
	[SerializeField] private Rigidbody rb;
	[SerializeField] private Transform target;
	[SerializeField] private OpponentTargetMovement targetLocation;
    [SerializeField] Animator animator;


	private float maxSpeed;
	private float radiusOfSat;

	void awake () {
		maxSpeed = 5f;
		radiusOfSat = 2f;
	}
	
	// Update is called once per frame
	void Update () {
			// Calculate vector from character to target
			Vector3 towards = target.position - trans.position;
			trans.rotation = Quaternion.LookRotation (towards);

			// If we haven't reached the target yet
			if (towards.magnitude > radiusOfSat) {

				// Normalize vector to get just the direction
				towards.Normalize ();
				towards *= maxSpeed;

				// Move character
				//rb.velocity = towards;
                rb.AddForce(towards, ForceMode.Impulse);
                towards = Vector3.zero;
			}
		
	}

}
