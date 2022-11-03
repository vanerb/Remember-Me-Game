using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveShop : MonoBehaviour
{
    public GameObject shop;
    public static bool isShopEnabled = false;
    
    // Start is called before the first frame update
    void Start()
    {
        shop.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            EnableShop();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            DisableShop();
        }
    }



    public void EnableShop()
    {
        Cursor.lockState = CursorLockMode.None;
        FindObjectOfType<OpenInventory>().CloseInventory();
        shop.SetActive(true);

    }

    public void DisableShop()
    {
        Cursor.lockState = CursorLockMode.Locked;
        shop.SetActive(false);
        
    }
}
