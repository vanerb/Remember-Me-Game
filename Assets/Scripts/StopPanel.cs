using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPanel : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        //panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFalse() {
        panel.SetActive(false);
    }

}
