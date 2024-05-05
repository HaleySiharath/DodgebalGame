using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textDisplay; //Display Box
    private string filePath;
    public string[] sentences; //Separated Lines
    private int index; //Line Index
    public float typingSpeed;
    
    public GameObject continueButton;

    public IEnumerator Start() {

        StartCoroutine(Type());
        filePath = Application.dataPath + "/Dialogue/DodgeballEndScene.txt";


        GetLineAtIndex(index);
        yield return null;
    }

    void Update() {
        if(textDisplay.text == sentences[index]) {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type() {
        foreach (char letter in sentences[index].ToCharArray()) {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private string GetLineAtIndex(int lineIndex) {
        sentences = File.ReadAllLines(filePath);

        if (lineIndex < sentences.Length) {
            return sentences[lineIndex];
        } else {
            return "End of Log";
        }
    }

    public void NextSentence() { //Might Have to Edit into different methods
        continueButton.SetActive(false);

        if(index < sentences.Length - 1) {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            //Deactivating Game Objects
            if (textDisplay.text.Contains("points")) {
                //Deactivate player named in sentence
            }
        } else {
            continueButton.SetActive(false);
            textDisplay.text = "";
            SceneManager.LoadScene(0);
        }
    }
}
