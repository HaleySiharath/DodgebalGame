using UnityEngine;

public class ScoringManager : MonoBehaviour
{
    public static ScoringManager Instance { get; private set;}

    public int score;

    private void Awake() {
        // If there is no Scoring Manager (first time running) then 
        // set instance to this scoring manager script
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    
    public void addScore(int point) {
        score += point;
    }

    public int getScore() {
        return score;
    }

}
