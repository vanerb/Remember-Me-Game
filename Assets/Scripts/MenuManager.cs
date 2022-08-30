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
        
    }

    public void NewGame()
    {
        /*random = Random.Range(1, 6);
        numRoom = random;
        PlayerPrefs.SetInt("numRoom", numRoom);
        SceneManager.LoadScene(random);*/


        //AÑADIDO PROVISIONAL
        FindObjectOfType<AudioManager>().Play("Button");

        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Room0");
    }

    public void Exit()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        Application.Quit();
    }

    public void Options()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Options");
    }

    public void Credits()
    {
        //CREDITOS
    }

    public void MainMenu()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

}
