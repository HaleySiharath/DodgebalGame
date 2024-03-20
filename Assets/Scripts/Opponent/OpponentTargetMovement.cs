using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentTargetMovement : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private float newLocationTimer;
    private Vector3 newLocation;

    // Start is called before the first frame update
    void Start() {
        newLocationTimer = 2;
        newLocation = Vector3.zero;
    }

    // Update is called once per frame
    void Update() {
        // // if the left mouse button is clicked move the target
        // if(Input.GetMouseButtonDown(0)) {

        //     // get world point location of mouse click
        //     Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        //     // check if ray hits anything on world and move the target
        //     if(Physics.Raycast(ray, out RaycastHit raycastHit)){
        //         transform.position = raycastHit.point;
        //     }
        // }
        // Give random positions every 2 seconds
        newLocationTimer -= Time.deltaTime;
        if(newLocationTimer < 0) {
            //give new location
            newLocation.x = Random.Range(-4.0f, 4.0f);
            newLocation.z = Random.Range(-4.0f, 4.0f);

            transform.position = newLocation;
            // Reset cooldown time
            coordCoolDown();
        }

        Debug.Log("Cool Down: " + newLocationTimer);
        Debug.Log("New Location: " + transform.position);

        

    }

    private void coordCoolDown() {
        if(newLocationTimer <= 0) {
            newLocationTimer = 2;
        }
    }

}
