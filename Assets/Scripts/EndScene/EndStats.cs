using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStats : MonoBehaviour
{
    [SerializeField] string contestantName;
    [SerializeField] public int score;
    // Start is called before the first frame update

    void Start()
    {
        contestantName = gameObject.name;

        if (gameObject.tag == "Player") {
            score = ScoringManager.Instance.getScore();
        } else {
           //score = (int) Random.Range(10.0f, 21.0f);
        }
    }

    public string getName() {
        return contestantName;
    }

    public int getScore() {
        return score;
    }

}
