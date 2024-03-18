using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPoint : MonoBehaviour
{
    public Transform target;
    private bool isShooting = false;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
