using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float speed = 4; //Ball speed
    [SerializeField] float destroyTime = 5f; //Time before ball is destroyed

    Rigidbody rb; //Variable to store Rigidbody component
    Vector3 lastVelocity; // For obtaining the last calculated velocity in Update()

    public bool thrownByPlayer = false;
    private bool thrown = false;

    //[SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        //Debug.Log("Thrown by player " + thrownByPlayer);
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
    
        if(thrownByPlayer) {	
            if(!thrown) {
                if(coll.gameObject.tag == "Opponent") {
                    ScoringManager.Instance.addScore(3);
                    Debug.Log(ScoringManager.Instance.getScore() + " Hit Opponent");
                } else {
                    ScoringManager.Instance.addScore(-2);
                    Debug.Log(ScoringManager.Instance.getScore() + " Missed Opponent");
                }

            }

        } else if (!thrownByPlayer) {
            if(!thrown) {
                if(coll.gameObject.tag == "Player") {
                    ScoringManager.Instance.addScore(-3);
                    Debug.Log(ScoringManager.Instance.getScore() + " Player Hit");
                } else {
                    ScoringManager.Instance.addScore(1);
                    Debug.Log(ScoringManager.Instance.getScore() + " Player Dodged");
                }
            }
        }

        thrown = true;


    }

}
