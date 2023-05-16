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
    public GameObject tutorial;
    public static bool ispassed = false;
    // Start is called before the first frame update
    void Start()
    {
        anim.enabled = false;
        ispassed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && isSpawned == false || Input.GetKeyDown(KeyCode.JoystickButton3) && isSpawned == false)
        {
            if(isIn == true)
            {
                FindObjectOfType<AudioManager>().Play("Chest");
                random = Random.Range(0, objects.Length);
                anim.Play("Active");
                Instantiate(objects[random], startPoint.transform.position, Quaternion.identity);
                isSpawned = true;
                ispassed = true;
                tutorial.SetActive(false);

            }

        }
    }

   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.enabled = true;
            isIn = true;
            if(ispassed == false)
            {
                tutorial.SetActive(true);

            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.enabled = false;
            isIn = false;
            tutorial.SetActive(false);
        }
    }
}
