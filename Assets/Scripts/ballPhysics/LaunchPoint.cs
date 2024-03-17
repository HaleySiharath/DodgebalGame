using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPoint : MonoBehaviour
{
    public Transform target;
    // Update is called once per frame
    void Update()
    {
        //For Aiming
        Vector3 targetDir = target.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);

        transform.LookAt(targetDir);
    }
}
