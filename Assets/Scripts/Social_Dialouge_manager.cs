using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class Social_Dialouge_manager : MonoBehaviour{
    public TMP_Text NPCDialogueText;
    public TMP_Dropdown PCDialogueDropdown;
    private string[,] DialogueFile;
    private int n = 0;

    void Start(){
        char lineDelimiter = '\n'; // Line delimiter
        char fieldDelimiter = ';'; // Field delimiter
        string commentPrefix = "//"; // Comment prefix
        string filePath = Path.Combine(Application.dataPath, "Dialogue/Dialogue_Template.txt");
        PCDialogueDropdown.onValueChanged.AddListener(delegate {DropdownValueChanged(PCDialogueDropdown);});
        if(File.Exists(filePath)){
            string[] lines = File.ReadAllLines(filePath);
            DialogueFile = new string[lines.Length, 5];
            for (int i = 0; i < lines.Length; i++){
                if (lines[i].Trim().StartsWith(commentPrefix)){continue;}
                string[] fields = lines[i].Split(fieldDelimiter);
                for (int j = 0; j < 5; j++){
                    DialogueFile[i, j] = fields[j].Trim();
                }
            }
        }
        SetText();
    }

    void DropdownValueChanged(TMP_Dropdown dropdown){
        ScoringManager.Instance.addScore(-1);
        if (!SetText()){
            // Break out of Dialoug here.
            Debug.Log("Dialouge is over.");
        }
    }

    bool SetText(){
        for(int i = 0; i < DialogueFile.GetLength(0);i++){
            if(int.Parse(DialogueFile[i,1])==(n*10)){
                if(DialogueFile[i,0]=="NPC"){//NPCs Turn
                    if(DialogueFile.GetLength(0)>i+1 && int.Parse(DialogueFile[i+1,1])<((n+1)*10)){//NPC Has Options
                        if(ScoringManager.Instance.getScore() >= 0){//Score is Positive
                            if(int.Parse(DialogueFile[i,2])==1){
                                NPCDialogueText.text = DialogueFile[i,3];
                                if(DialogueFile[i,4]=="Break"){return false;}
                            }else{
                                NPCDialogueText.text = DialogueFile[i+1,3];
                                if(DialogueFile[i+1,4]=="Break"){return false;}
                            }
                        }else{//Score is negative
                           if(int.Parse(DialogueFile[i,2])==-1){
                                NPCDialogueText.text = DialogueFile[i,3];
                                if(DialogueFile[i,4]=="Break"){return false;}
                            }else{
                                NPCDialogueText.text = DialogueFile[i+1,3];
                                if(DialogueFile[i+1,4]=="Break"){return false;}
                            } 
                        }
                    }else{//NPC has one option
                        NPCDialogueText.text = DialogueFile[i,3];
                        if(DialogueFile[i,4]=="Break"){return false;}
                    }
                    n++;
                    continue;
                }else{//PCs Turn
                    List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
                    options.Add(new TMP_Dropdown.OptionData("Please Select an option Below."));
                    options.Add(new TMP_Dropdown.OptionData(DialogueFile[i,3]));
                    for(int j=1;int.Parse(DialogueFile[i+j,1])<((n+1)*10);j++){
                        options.Add(new TMP_Dropdown.OptionData(DialogueFile[i+j,3]));
                        if(DialogueFile.GetLength(0)>=i+j+1){break;}
                    }
                    PCDialogueDropdown.options = options;
                    PCDialogueDropdown.value = 0;
                    n++;
                    break;
                }
            }
        }
        return true;
    }
}
//ScoringManager.Instance.addScore(-n);   
//ScoringManager.Instance.getScore();


// TODO Integrate
// TODO Merge into Main Game