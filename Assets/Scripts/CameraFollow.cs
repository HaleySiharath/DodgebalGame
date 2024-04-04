using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 cameraOffset;

    // Update is called once per frame
    void Update()
    {
        //if (SceneManager.GetActiveScene() == "SocialScene") {Incorporate the following}
        //Change camera behavior for different scenes

        transform.position = player.position + cameraOffset;

    }
}
