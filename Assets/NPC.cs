using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    public GameObject contButton;
    private int index;
    public float wordSpeed;
    public bool playerIsClose;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose) {
            if(dialoguePanel.activeInHierarchy) {
                zeroText();
            }
            else {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
                Debug.Log("Displaying dialogue panel");
            }
        }
        if(dialogueText.text == dialogue[index]) {
            contButton.SetActive(true);
            Debug.Log("button not clicked");
        }
        
    }

    IEnumerator Typing() {
        foreach (char letter in dialogue[index].ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine() {

        Debug.Log("button clicked");
        contButton.SetActive(false);

        if(index < dialogue.Length - 1) {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else {
            zeroText();
        }
    }

    public void zeroText() {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            playerIsClose = false; 
            zeroText();
        }
    }


}
