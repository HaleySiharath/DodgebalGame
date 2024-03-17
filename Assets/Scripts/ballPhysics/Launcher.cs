using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{

    public Transform barrelOut; //Dodgeball Spawnpoint
    public GameObject projectile; //Instantiated dodgeball


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { //Throwing mechanic
            Shoot();
        }
    }

    void Shoot() {
        GameObject newProj = Instantiate(projectile, barrelOut.position, barrelOut.rotation);
    }
}
