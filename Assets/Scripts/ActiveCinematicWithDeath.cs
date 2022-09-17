using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCinematicWithDeath : MonoBehaviour
{
    public EnemyLife enemyLife;
    public Animator anim;
    public bool isEnabled = false;
    public GameObject cinematic;

    // Start is called before the first frame update
    void Start()
    {
        anim.enabled = false;
        cinematic.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyLife.currentHealth <= 0)
        {
            isEnabled = true;
           
        }


        if(isEnabled == true)
        {
            cinematic.SetActive(true);
            anim.enabled = true;
            anim.Play("Active");
        }
        else if(isEnabled == false)
        {
            cinematic.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            isEnabled = false;
        }
    }

    public void SetFalse()
    {
        isEnabled = false;
    }
}
