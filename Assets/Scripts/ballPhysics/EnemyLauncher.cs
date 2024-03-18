using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLauncher : MonoBehaviour
{

    public Transform barrelOut; //Dodgeball Spawnpoint
    public GameObject projectile; //Instantiated dodgeball
    public bool isShooting;

    void Start() {
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { //Change to action taken when throwing is wanted (i.e. stopping, turning around, etc.)
            Shoot();
        }
    }

    void Shoot() {
        isShooting = true;
        GameObject newProj = Instantiate(projectile, barrelOut.position, barrelOut.rotation);
        isShooting = false;
    }
}
