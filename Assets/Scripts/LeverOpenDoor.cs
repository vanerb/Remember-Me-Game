using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverOpenDoor : MonoBehaviour
{

    public bool isActive;
   
    public Animator anim;

    public bool isInside;

    // Start is called before the first frame update
    void Start()
    {
        anim.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.C) && isInside == true){
            FindObjectOfType<AudioManager>().Play("Lever");
            anim.enabled = true;
                isActive = true;
                anim.Play("Active");
            }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInside = true;
          
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.enabled = false;
            isInside = false;
        }
    }
}
