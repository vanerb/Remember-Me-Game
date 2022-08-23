using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider2D colliderLimit;
    public Animator anim;
    public LeverOpenDoor lever;
    void Start()
    {
        colliderLimit.enabled = true;
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(lever.isActive == true)
        {
            anim.enabled = true;
            anim.Play("Open");
            Debug.Log("ESTOY ABIERTO");
           // lever.isActive = false;
            colliderLimit.enabled = false;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.enabled = false;
        }
    }
}
