using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStorageBook : MonoBehaviour
{
    public GameObject bookStorage;
    public static bool isActive = true;
    

    // Start is called before the first frame update
    void Start()
    {
        bookStorage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {

            CloseInventory();
        }


    }

    public void OpenClose()
    {
        if (isActive)
        {
            OpenInventori();

        }
        else
        {
            CloseInventory();

        }
    }

    public void OpenInventori()
    {
        FindObjectOfType<OpenBook>().CloseBook();
        FindObjectOfType<PauseMenu>().Resume();
        Cursor.lockState = CursorLockMode.None;
        FindObjectOfType<AudioManager>().Play("Pause");

        bookStorage.SetActive(true);
        isActive = false;
    }

    public void CloseInventory()
    {
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<AudioManager>().Play("UnPause");

        bookStorage.SetActive(false);
        isActive = true;
    }
}
