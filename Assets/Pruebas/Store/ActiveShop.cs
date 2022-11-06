using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveShop : MonoBehaviour
{
    public GameObject shop;
    public static bool isShopEnabled = false;
    public bool isEnter = false;
    public bool isActive = false;
    public GameObject prevent;
    
    // Start is called before the first frame update
    void Start()
    {
        shop.SetActive(false);
        prevent.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnter)
        {
            Cursor.lockState = CursorLockMode.None;
            if (Input.GetKeyDown(KeyCode.Joystick1Button3) || Input.GetKeyDown(KeyCode.C))
            {
                if (isActive)
                {
                    
                    DisableShop();
                }
                else
                {
                    
                    EnableShop();
                }
            }
        }
       
        


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            
            prevent.SetActive(true);
            isEnter = true;
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            //EnableShop();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.Locked;

            prevent.SetActive(false);
            
            isEnter = false;
            //DisableShop();
        }
    }



    public void EnableShop()
    {
        
        isActive = true;
        isShopEnabled = true;
        
        FindObjectOfType<OpenInventory>().CloseInventory();
        shop.SetActive(true);

    }

    public void DisableShop()
    {
        
        isActive = false;
        isShopEnabled = false;
        
        shop.SetActive(false);
        
    }
}
