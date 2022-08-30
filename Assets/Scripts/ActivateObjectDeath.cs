using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectDeath : MonoBehaviour
{
    public GameObject objectAct;
    public ActivateDoorDeath activate;

    // Start is called before the first frame update
    void Start()
    {
        objectAct.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(activate.isDeath == true)
        {
            objectAct.SetActive(true);
        }
    }



}
