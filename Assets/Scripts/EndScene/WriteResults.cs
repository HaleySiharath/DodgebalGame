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

    public List<GameObject> contestants = new List<GameObject>();

    // Start is called before the first frame update
    void Start() {
        filePath = Application.dataPath + "/Dialogue/DodgeballEndSceneText.txt";
        
        //Adding values to ranking array
        contestants.Add(player);
        contestants.Add(npc1);
        contestants.Add(npc2);
        contestants.Add(npc3);
        contestants.Add(npc4);

        contestants.Sort(CompareScores);
        Rewrite();
    }

    private int CompareScores(GameObject a, GameObject b) {
        return a.GetComponent<EndStats>().getScore().CompareTo(a.GetComponent<EndStats>().getScore());
    }

    private void Rewrite() {
        string[] lines = File.ReadAllLines(filePath);
        int i; //index of lines
        for (i = 0; i < lines.Length - 1; i++) {
            string nextName = contestants[i].GetComponent<EndStats>().getName();
            int nextScore = contestants[i].GetComponent<EndStats>().getScore();
            if (lines[i].Contains("XXXX with")) {
                lines[i] = lines[i].Replace("XXXX with", nextName + " with");
            }
            if (lines[i].Contains("XXXX points")) {
                lines[i] = lines[i].Replace("XXXX points", nextScore + " points");
            }

            print(lines[i]);
        }
    }
}