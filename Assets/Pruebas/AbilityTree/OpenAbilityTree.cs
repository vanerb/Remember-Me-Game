using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAbilityTree : MonoBehaviour
{
    public GameObject abilityTree;
    public static bool isEnabled;

    // Start is called before the first frame update
    void Start()
    {
        isEnabled = true;
        abilityTree.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

       /* if (Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            OpenClose();
        }*/
    }

    public void OpenClose()
    {
        if (isEnabled)
        {
            OpenTree();

        }
        else
        {
            CloseTree();

        }
    }

    public void OpenTree()
    {

        FindObjectOfType<OpenStorageBook>().CloseInventory();
        FindObjectOfType<PauseMenu>().Resume();
        Cursor.lockState = CursorLockMode.None;
        FindObjectOfType<AudioManager>().Play("Pause");
        abilityTree.SetActive(true);

        isEnabled = false;
    }

    public void CloseTree()
    {

        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<AudioManager>().Play("UnPause");

        abilityTree.SetActive(false);
        isEnabled = true;
    }
}
