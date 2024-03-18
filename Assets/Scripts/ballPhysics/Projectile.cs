using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float speed = 4; //Ball speed
    float destroyTime = 5f; //Time before ball is destroyed

    Rigidbody rb; //Variable to store Rigidbody component
    Vector3 lastVelocity; // For obtaining the last calculated velocity in Update()

    //[SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity; //Read the current velocity
        
        Destroy(gameObject, destroyTime);
    }

    
    private void OnCollisionEnter(Collision coll) {

        //source.PlayOneShot(clip);
        
        
        var speed = lastVelocity.magnitude; //The speed of the ball right before impact

        
        var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed / 1.05f, 0f); //Set the new velocity of the ball
        
    }
    
}
