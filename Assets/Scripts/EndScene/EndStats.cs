using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStats : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private int score;
    // Start is called before the first frame update

    void Start()
    {
        name = gameObject.name;

        if (name == "Player") {
            score = ScoringManager.Instance.getScore();
        } else {
            score = (int) Random.Range(10.0f, 21.0f);
        }
    }

    public string getName() {
        return name;
    }

    public int getScore() {
        return score;
    }

}
