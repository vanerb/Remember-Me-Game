using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour
{

    public bool isEnabled = false;
    public GameObject info;
    
    // Start is called before the first frame update
    void Start()
    {
        isEnabled = false;
        info.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnabled == true)
        {
            info.SetActive(true);
            

        }
        else
        {
            info.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isEnabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isEnabled = false;
        }
    }
}
