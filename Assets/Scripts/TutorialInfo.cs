using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInfo : MonoBehaviour
{

    public GameObject info;
    public bool isEnter;
    public BoxCollider2D detect;

    // Start is called before the first frame update
    void Start()
    {
        info.SetActive(false);
        isEnter = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnter == true)
        {
            
            info.SetActive(true);
            Time.timeScale = 0;
            

        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            
            isEnter = false;
            Time.timeScale = 1;
            info.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Notification");
            isEnter = true;
            detect.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detect.enabled = false;
        }
    }
}
