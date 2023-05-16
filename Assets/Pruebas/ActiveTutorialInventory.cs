using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTutorialInventory : MonoBehaviour
{
    public static bool ispassed;
    public GameObject tutorial;
    // Start is called before the first frame update
    void Start()
    {
        ispassed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ispassed = true;
            tutorial.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (ispassed == false)
            {
                tutorial.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tutorial.SetActive(false);

        }
    }
}
