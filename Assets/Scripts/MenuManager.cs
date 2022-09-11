using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    private int random;
    private int numRoom;

    public void Play()
    {
        //SceneManager.LoadScene(PlayerPrefs.GetInt("numRoom"));
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Room0");
        Time.timeScale = 1f;
        //FindObjectOfType<AudioManager>().Play("MainTheme");
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Tutorial()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Tutorial");
    }

    public void NewGame()
    {
        //random = Random.Range(1, SceneManager.sceneCountInBuildSettings);
        //Debug.Log("LA ROOM TOTAL ES DE: " + random);
        /*numRoom = random;
        PlayerPrefs.SetInt("numRoom", numRoom);
        SceneManager.LoadScene(random);*/


        //AÑADIDO PROVISIONAL
        //FindObjectOfType<AudioManager>().Play("Button");
        Cursor.lockState = CursorLockMode.Locked;
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Room0");
    }

    public void Exit()
    {
        Cursor.lockState = CursorLockMode.None;
        FindObjectOfType<AudioManager>().Play("Button");
        Application.Quit();
    }

    public void Options()
    {
        Cursor.lockState = CursorLockMode.None;
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Options");
    }

    public void Credits()
    {
        Cursor.lockState = CursorLockMode.None;
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Credits");   
        //CREDITOS
    }

    public void MainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

}
