using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSheet : MonoBehaviour
{
    public Dialogue dialogue;


    public void Active()
    {
        FindObjectOfType<BookSheet>().StartDialogue(dialogue);
        
    }

   
}
