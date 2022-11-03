using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject inventory;
    public static bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
        inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Joystick1Button6))
        {

            OpenClose();
        }
    }

    public void OpenClose()
    {
        if (isActive)
        {
            if(!ActiveShop.isShopEnabled && !LifePlayer.isDeath && !PauseMenu.isActive)
            {
                OpenInventori();
            }
            
            
        }
        else
        {
            CloseInventory();
            
        }
    }

    public void OpenInventori()
    {
        Cursor.lockState = CursorLockMode.None;
        FindObjectOfType<AudioManager>().Play("Pause");

        inventory.SetActive(true);
        isActive = false;
    }

    public void CloseInventory()
    {
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<AudioManager>().Play("UnPause");

        inventory.SetActive(false);
        isActive = true;
    }
}
