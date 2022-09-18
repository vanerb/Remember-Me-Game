using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeNull : MonoBehaviour
{
    //public GameObject panelError;
    
    public Button buttonPlay;
    // Start is called before the first frame update
    void Start()
    {
        //panelError.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("numRoom") == 0)
        {
            //panelError.SetActive(true);
            buttonPlay.interactable = false;
            
        }
        else
        {
            buttonPlay.interactable = true;
        }

        
        
        
    }

}
