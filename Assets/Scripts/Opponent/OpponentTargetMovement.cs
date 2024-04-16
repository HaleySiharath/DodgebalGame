using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentTargetMovement : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float minX = -14f;
    [SerializeField] private float maxX = 17f;
    [SerializeField] private float minZ = 10f;
    [SerializeField] private float maxZ = 41f;

    private float newLocationTimer;
    private Vector3 newLocation;

    // Start is called before the first frame update
    void Start() {
        newLocationTimer = 4;
        newLocation = Vector3.zero;
    }

    // Update is called once per frame
    void Update() {
        // Give random positions every 2 seconds
        newLocationTimer -= Time.deltaTime;
        if(newLocationTimer < 0) {
            //give new location
            newLocation.x = Random.Range(minX, maxX);
            newLocation.z = Random.Range(minZ, maxZ);

            transform.position = newLocation;
            // Reset cooldown time
            coordCoolDown();
        }

        //Debug.Log("Cool Down: " + newLocationTimer);
        //Debug.Log("New Location: " + transform.position);

        

    }

    private void coordCoolDown() {
        if(newLocationTimer <= 0) {
            newLocationTimer = 4;
        }
    }

}
