using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnim : MonoBehaviour
{
    public Sprite imgNormal;
    public Sprite imgPressed;
    public Image imgStatic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Enter()
    {
        imgStatic.sprite = imgPressed;
        FindObjectOfType<AudioManager>().Play("ButtonPress");
    }

    public void Exit()
    {
        imgStatic.sprite = imgNormal;
    }

    
}
