using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaunchPoint : MonoBehaviour
{
    public Transform target;
    private int aimRng;
    [SerializeField] private EnemyLauncher enemyLauncherObj;

    // Update is called once per frame
    void Update()
    {
        //aimRng = (int) Random.Range(0f, 4f);

        if(enemyLauncherObj.isShooting) { //This code will be changed later for variation, right now it will only target player
            if (aimRng == 0) {
                transform.LookAt(target, Vector3.up);
                //Debug.Log("first if");
            } else {
                transform.Rotate((int) Random.Range(-15f, 15f), (int) Random.Range(-270f, -90f), 0f, Space.Self);
                //Debug.Log("second if");
            }

        }
    }
}
