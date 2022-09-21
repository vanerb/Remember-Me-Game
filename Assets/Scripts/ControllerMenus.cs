using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMenus : MonoBehaviour
{


    public GameObject[] menus;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < menus.Length; i++)
        {
            if(menus[i].active == true)
            {
                menus[i].SetActive(false);
            }
        }
    }
}
