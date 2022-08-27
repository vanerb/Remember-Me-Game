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
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Room0");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Credits()
    {
        //CREDITOS
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

}
