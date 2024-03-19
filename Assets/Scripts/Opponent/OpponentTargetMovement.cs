using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentTargetMovement : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        // if the left mouse button is clicked move the target
        if(Input.GetMouseButtonDown(0)) {

            // get world point location of mouse click
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // check if ray hits anything on world and move the target
            if(Physics.Raycast(ray, out RaycastHit raycastHit)){
                transform.position = raycastHit.point;
            }
        }
    }

}
