using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    Plane plane = new Plane(Vector3.forward, -20);

    // Update is called once per frame
    void Update()
    {
        screenPosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        
        if (plane.Raycast(ray, out float distance)) {
            worldPosition = ray.GetPoint(distance);
        }

        transform.position = worldPosition;
    }
}
