using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStay : MonoBehaviour
{


    public void ButtonPressed()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
