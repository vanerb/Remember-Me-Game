using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
    public DialogueEnglish dialogueEnglish;
	public void TriggerDialogue ()
	{
        
        if (PlayerPrefs.GetString("SelectedLanguage") == "Inglés")
        {
            FindObjectOfType<DialogueManager>().StartDialogueEnglish(dialogueEnglish);

        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            Debug.Log(PlayerPrefs.GetString("SelectedLanguage"));
            if (PlayerPrefs.GetString("SelectedLanguage") == "Inglés")
            {
                FindObjectOfType<DialogueManager>().StartDialogueEnglish(dialogueEnglish);

            }
            else
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerPrefs.GetString("SelectedLanguage") == "Inglés")
            {
                FindObjectOfType<DialogueManager>().EndDialogue();

            }
            else
            {
                FindObjectOfType<DialogueManager>().EndDialogue();

            }
        }
    }


}
