using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isActive = false;
    public GameObject panelPause;
    public AudioSource menuMusic;


    // Start is called before the first frame update
    void Start()
    {
        panelPause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(LifePlayer.isDeath == true)
        {
            this.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            if (isActive)
            {
                
                Resume();
            }
            else
            {
                
                Pause();
            }

        }

       

       
    }

    public void Resume()
    {
        menuMusic.Play();
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<AudioManager>().Play("UnPause");
        panelPause.SetActive(false);
        isActive = false;
        Time.timeScale = 1f;
    }

   

    public void Pause()
    {
        menuMusic.Pause();
        FindObjectOfType<BookSheet>().EndDialogue();
        FindObjectOfType<OpenBook>().CloseBook();
        FindObjectOfType<OpenStorageBook>().CloseInventory();
        FindObjectOfType<ActiveShop>().DisableShop();
        Cursor.lockState = CursorLockMode.None;
        FindObjectOfType<AudioManager>().Play("Pause");
        
        panelPause.SetActive(true);
        isActive = true;
        Time.timeScale = 0f;
    }
}
