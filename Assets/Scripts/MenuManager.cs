using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    private int random;
    

    public void Play()
    {
        // SceneManager.LoadScene(PlayerPrefs.GetInt("numRoom"));

        random = Random.Range(4, SceneManager.sceneCountInBuildSettings);
        
        SceneManager.LoadScene(random);
        TakeLife.pickObject = 0;
        PlayerPrefs.DeleteAll();
        //A�ADIDO PROVISIONAL
        //FindObjectOfType<AudioManager>().Play("Button");
        Cursor.lockState = CursorLockMode.Locked;
        //PlayerPrefs.DeleteAll();
        // SceneManager.LoadScene("Room0");

    }

    public void Tutorial()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Tutorial");
        
    }

   /* public void NewGame()
    {
        random = Random.Range(4, SceneManager.sceneCountInBuildSettings);
        //Debug.Log("LA ROOM TOTAL ES DE: " + random);
        //PlayerPrefs.SetInt("numRoom", random);
        SceneManager.LoadScene(random);
        //A�ADIDO PROVISIONAL
        //FindObjectOfType<AudioManager>().Play("Button");
        Cursor.lockState = CursorLockMode.Locked;
        //PlayerPrefs.DeleteAll();
       // SceneManager.LoadScene("Room0");
    }*/

    public void Exit()
    {
        Cursor.lockState = CursorLockMode.None;
        //FindObjectOfType<AudioManager>().Play("Button");
        Application.Quit();
        
    }

    public void Options()
    {
        Cursor.lockState = CursorLockMode.None;
        //FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Options");
        
    }

    public void Credits()
    {
        Cursor.lockState = CursorLockMode.None;
        //FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Credits");
        
        //CREDITOS
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        PauseMenu.isActive = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        //FindObjectOfType<AudioManager>().Play("Button");
        
    }

}
