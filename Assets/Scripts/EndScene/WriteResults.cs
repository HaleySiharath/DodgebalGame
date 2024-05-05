using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WriteResults : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject npc1;
    [SerializeField] private GameObject npc2;
    [SerializeField] private GameObject npc3;
    [SerializeField] private GameObject npc4;


    private string filePath;
    private string filePathToChange;

    public List<GameObject> contestants = new List<GameObject>();
    public List<GameObject> contestantsSorted = new List<GameObject>();
    [SerializeField] EndDialogue endDialogue;

    // Start is called before the first frame update
    void Start() {
        filePath = Application.dataPath + "/Dialogue/DodgeballEndSceneText.txt";
        filePathToChange = Application.dataPath + "/Dialogue/DodgeballEndScene.txt";
        
        //Adding values to ranking array
        contestants.Add(player);
        contestants[0].GetComponent<EndStats>().score = ScoringManager.Instance.getScore();

        contestants.Add(npc1);
        contestants.Add(npc2);
        contestants.Add(npc3);
        contestants.Add(npc4);

        contestants.Sort(CompareScores);

        for (int z = contestants.Count - 1; z > -1; z--)
        {
            contestantsSorted.Add(contestants[z]);
        }

       Rewrite();
    }

    static int CompareScores(GameObject a, GameObject b) {
        int score1 = a.GetComponent<EndStats>().getScore();
        int score2 = b.GetComponent<EndStats>().getScore();
        return score1.CompareTo(score2);
    }

    private void Rewrite() {
        string[] lines = File.ReadAllLines(filePath);

        int i; //index of lines
        // for (int z = 0; z < contestantsSorted.Count; z++)
        // {
        //     print(contestantsSorted[z].GetComponent<EndStats>().getScore());
        //     print(contestantsSorted[z].GetComponent<EndStats>().getName());

        // }
        for (i = 0; i < lines.Length; i++) {
             if(i != 0 && i != lines.Length - 1) {
                string nextName = contestantsSorted[i - 1].GetComponent<EndStats>().getName();
                int nextScore = contestantsSorted[i - 1].GetComponent<EndStats>().getScore();

                if (lines[i].Contains("XXXX with")) {
                    lines[i] = lines[i].Replace("XXXX with", nextName + " with");
                }
                if (lines[i].Contains("XXXX points")) {
                    lines[i] = lines[i].Replace("XXXX points", nextScore + " points");
                }
             }

            // print(lines[i]);
        }

        File.WriteAllLines(filePathToChange, lines);
        StartCoroutine(endDialogue.Start());
    }
}