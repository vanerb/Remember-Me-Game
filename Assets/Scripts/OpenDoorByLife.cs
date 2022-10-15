using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorByLife : MonoBehaviour
{

    public ActivateDoorDeath active;
    public Animator anim;
    public BoxCollider2D colliderLimit;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(active.isDeath == true)
        {
            
            anim.enabled = true;
            anim.Play("Open");
            Debug.Log("ESTOY ABIERTO");
            // lever.isActive = false;
            colliderLimit.enabled = false;
        }
    }
}
