using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactiveTutorial : MonoBehaviour
{
    public ActivateDoorDeath active;
    public GameObject message;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (active.isDeath == true)
        {
            message.SetActive(false);
        }
    }
}
