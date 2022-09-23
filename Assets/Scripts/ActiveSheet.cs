using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSheet : MonoBehaviour
{
    public Dialogue dialogue;
    public static bool isActive;
    

    public void Active()
    {
        isActive = true;
        FindObjectOfType<BookSheet>().StartDialogue(dialogue);
        
    }



   
}
