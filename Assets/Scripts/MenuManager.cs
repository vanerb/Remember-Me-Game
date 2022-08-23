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
        SceneManager.LoadScene(PlayerPrefs.GetInt("numRoom"));
        
        Time.timeScale = 1f;
        
    }

    public void NewGame()
    {
        random = Random.Range(1, 6);
        numRoom = random;
        PlayerPrefs.SetInt("numRoom", numRoom);
        SceneManager.LoadScene(random);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Options()
    {
        //OPCIONES
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
