using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] objects;
    private int random;
    public Transform startPoint;
    public bool isSpawned = false;
    public bool isIn = false;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Joystick1Button3) && isSpawned == false)
        {
            if(isIn == true)
            {
                FindObjectOfType<AudioManager>().Play("Chest");
                random = Random.Range(0, objects.Length);
                anim.Play("Active");
                Instantiate(objects[random], startPoint.transform.position, Quaternion.identity);
                isSpawned = true;
            }
           
        }
    }

   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.enabled = true;
            isIn = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.enabled = false;
            isIn = false;
        }
    }
}
