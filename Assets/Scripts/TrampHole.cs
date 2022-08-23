using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampHole : MonoBehaviour
{
    private float time;
    public float timeToFall;
    private bool isEntered = false;
    public GameObject player;
    public Animator anim;
    public PlayerController playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        isEntered = false;
        time = timeToFall;
    }

    // Update is called once per frame
    void Update()
    {
        if(isEntered == true)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                anim.Play("Activate");
                playerController.enabled = false;
                
                Invoke("ActivateLife", 0.7f);
            }
        }
    }

    void ActivateLife()
    {
        player.gameObject.GetComponent<LifePlayer>().TakeDamage(100);
        time = timeToFall;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isEntered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isEntered = false;
        }
    }
}
