using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{

    public Transform barrelOut; //Dodgeball Spawnpoint
    public GameObject projectile; //Instantiated dodgeball
    [SerializeField] private float seconds; //Number of seconds before dodgeball created

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonDown(0)) { //Throwing mechanic
        //     Shoot();
        // }
    }

    public IEnumerator Shoot() {
        yield return new WaitForSeconds(seconds);
        GameObject newProj = Instantiate(projectile, barrelOut.position, barrelOut.rotation);
    }


}
