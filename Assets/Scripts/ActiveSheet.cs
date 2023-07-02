using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSheet : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueEnglish dialogueEnglish;
    public static bool isActive;
    

    public void Active()
    {
        isActive = true;
       


        if (PlayerPrefs.GetString("SelectedLanguage") == "Inglés")
        {
            FindObjectOfType<BookSheet>().StartDialogueEnglish(dialogueEnglish);

        }
        else
        {
            FindObjectOfType<BookSheet>().StartDialogue(dialogue);

        }

    }



   
}
