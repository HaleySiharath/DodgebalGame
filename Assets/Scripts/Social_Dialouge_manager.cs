using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class Social_Dialouge_manager : MonoBehaviour{
    public TMP_Text NPCDialogueText;
    public TMP_Text PCDialogueText;
    private string[] DialogueFile;
    private int n = 0;
    // Start is called before the first frame update
    void Start(){
        string filePath = Path.Combine(Application.dataPath, "Dialogue/Dialogue_Template.txt");
        if(File.Exists(filePath)){
            DialogueFile = File.ReadAllLines(filePath);
        }
    
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetMouseButtonDown(0)){ // 0 is the button number for left click
            ChangeText();
        }
    }

    void ChangeText(){
        if (DialogueFile != null){
            if(n >= DialogueFile.Length){
                n = 0;
            }
            NPCDialogueText.text = "NPC says: " + DialogueFile[n];
            PCDialogueText.text = "PC says: " + DialogueFile[n];
            n++;
        }



    }

}

// TODO Enter the Dialogue fill into an object that can return appropriate text for each NPC / PC
// TODO Update GUI to allow PC to Select Text Option
// TODO Integrate
// TODO Merge into Main Game