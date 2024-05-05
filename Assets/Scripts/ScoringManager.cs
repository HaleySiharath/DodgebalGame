using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoringManager : MonoBehaviour
{
    public static ScoringManager Instance { get; private set;}
    [SerializeField] AudioSource audio;
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


    private void Update() {
         if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

         if (Input.GetKeyDown("1"))
        {
            score = -1000;
        }

         if (Input.GetKeyDown("2"))
        {
            score = 1000;
        }
    }
    
    public void addScore(int point) {
        score += point;
    }

    public int getScore() {
        return score;
    }

}
