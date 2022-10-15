using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBook : MonoBehaviour
{
    public GameObject book;
    public static bool isBookEnabled;

    // Start is called before the first frame update
    void Start()
    {
        isBookEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
      
        /*if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            OpenClose();
        }*/
    }

    public void OpenClose()
    {
        if (isBookEnabled)
        {
            OpenBookk();

        }
        else
        {
            CloseBook();

        }
    }

    public void OpenBookk()
    {
        
        FindObjectOfType<OpenStorageBook>().CloseInventory();
        FindObjectOfType<PauseMenu>().Resume();
        Cursor.lockState = CursorLockMode.None;
        FindObjectOfType<AudioManager>().Play("Pause");
        
        book.SetActive(true);
  
        isBookEnabled = false;
    }

    public void CloseBook()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<AudioManager>().Play("UnPause");

        book.SetActive(false);
        isBookEnabled = true;
    }
}
