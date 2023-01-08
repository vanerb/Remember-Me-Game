using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMap : MonoBehaviour
{
    public GameObject map;
    public static bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
        map.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.M))
        {

            OpenClose();
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
        Cursor.lockState = CursorLockMode.None;
        FindObjectOfType<AudioManager>().Play("Pause");
        map.SetActive(true);
        isActive = false;
    }

    public void CloseInventory()
    {
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<AudioManager>().Play("UnPause");

        map.SetActive(false);
        isActive = true;
    }
}
