using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject inventory;
    private bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
        inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
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
        inventory.SetActive(true);
        isActive = false;
    }

    public void CloseInventory()
    {
        inventory.SetActive(false);
        isActive = true;
    }
}
