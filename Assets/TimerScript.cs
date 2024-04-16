using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private float startTime;
    private bool timeStarted;
    private float currentTime;
    private int minutes;
    private int seconds;   
    [SerializeField] TMP_Text timerText;
    void Start()
    {
        currentTime = startTime;
        timeStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeStarted) {
            currentTime -= Time.deltaTime;

            if(currentTime <= 0) {
                Debug.Log("Timer has reached 0");
                timeStarted = false;
                currentTime = 0;

                SceneManager.LoadScene(0);
            }

            minutes = Mathf.FloorToInt(currentTime / 60F);
            seconds = Mathf.FloorToInt(currentTime - minutes * 60);

            string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            timerText.text = niceTime;
        }
    }
}
