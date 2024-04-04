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

    public void Shoot() {
        isShooting = true;
        GameObject newProj = Instantiate(projectile, barrelOut.position, barrelOut.rotation);
        isShooting = false;
    }
}
