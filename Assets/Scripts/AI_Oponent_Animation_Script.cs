using UnityEngine;
using System;

public class AI_Oponent_Animation_Script : MonoBehaviour{
    private Animator animator;
    void Start(){
        animator = GetComponent<Animator>();
    }
    void Update(){
        animator.SetBool("Is_Idle",false);
        animator.SetBool("Is_Running",false);
        animator.SetBool("Is_Turning_Left",false);
        animator.SetBool("Is_Turning_Right",false);
        animator.SetBool("Is_Throwing",false);
        
        int num = GetWeightedRandomInt();
        if(num==0){
            animator.SetBool("Is_Idle",true);
        }else if(num==1){
             animator.SetBool("Is_Running",true);
        }else if(num==2){
             animator.SetBool("Is_Turning_Left",true);
        }else if(num==3){
             animator.SetBool("Is_Turning_Right",true);
        }else if(num==4){
             animator.SetBool("Is_Throwing",true);
        }

    }

    private static System.Random random = new System.Random();
    public static int GetWeightedRandomInt(){
        int[] values = { 0, 1, 2, 3, 4 };// 0=Idle 1=Run 2=Left 3=right 4=throw
        float[] weights = { 0.07f, 0.4f, 0.2f, 0.3f, 0.03f };
        float totalWeight = 0f;

        foreach (float weight in weights){
            totalWeight += weight;
        }

        float randomNumber = (float)(random.NextDouble() * totalWeight);

        float sum = 0f;
        for (int i = 0; i < weights.Length; i++){
            sum += weights[i];
            if (randomNumber <= sum){
                return values[i];
            }
        }
        return values[0];
    }       
}
