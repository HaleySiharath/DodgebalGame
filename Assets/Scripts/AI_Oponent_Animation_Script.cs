using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Oponent_Animation_Script : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Is_Idle",true);
    }
}
