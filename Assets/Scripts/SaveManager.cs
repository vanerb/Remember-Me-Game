using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public float posX;
    public float posY;
    public Vector2 positionPlayer;
    public ChangeLife changeLife;
    
    // Start is called before the first frame update
    void Start()
    {

        LoadData();
        
        Time.timeScale = 1;

    }

    


    public void LoadData()
    {
        posX = PlayerPrefs.GetFloat("PosicionX");
        posY = PlayerPrefs.GetFloat("PosicionY");

        positionPlayer.x = posX;
        positionPlayer.y = posY;

        transform.position = positionPlayer;

        
        //textLoad.SetActive(true);
        //textSave.SetActive(false);
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("PosicionX", transform.position.x);
        PlayerPrefs.SetFloat("PosicionY", transform.position.y);

        

        //textSave.SetActive(true);
        //textLoad.SetActive(false);

    }

    public void BorrarDatos()
    {
        PlayerPrefs.DeleteAll();
    }


    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SaveData();
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            LoadData();
        }



    }



}
