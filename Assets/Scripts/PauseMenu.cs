using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool isActive = false;
    public GameObject panelPause;


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
        if (Input.GetKeyDown(KeyCode.Escape))
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

    void Resume()
    {
        FindObjectOfType<AudioManager>().Play("UnPause");
        panelPause.SetActive(false);
        isActive = false;
        Time.timeScale = 1f;
    }

    void Pause()
    {
        FindObjectOfType<AudioManager>().Play("Pause");
        panelPause.SetActive(true);
        isActive = true;
        Time.timeScale = 0f;
    }
}
