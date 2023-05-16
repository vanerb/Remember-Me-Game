using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverOpenDoor : MonoBehaviour
{

    public bool isActive;
   
    public Animator anim;

    public bool isInside;

    public CameraFollowObject cameraController;
    public int focusPointIndex;
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
         if(Input.GetKeyDown(KeyCode.C) && isInside == true)
         {
            FindObjectOfType<AudioManager>().Play("Lever");
            anim.enabled = true;
                isActive = true;
                anim.Play("Active");
            Camera.main.GetComponent<CameraFollow>().ShakeCamera(0.3f, 0.3f);
            Activate();
            ispassed = true;
            tutorial.SetActive(false);

        }

        if (Input.GetKeyDown(KeyCode.JoystickButton3) && isInside == true)
        {
            FindObjectOfType<AudioManager>().Play("Lever");
            anim.enabled = true;
            isActive = true;
            anim.Play("Active");
            Camera.main.GetComponent<CameraFollow>().ShakeCamera(0.2f, 0.2f);
            Activate();
            ispassed = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInside = true;
            
          
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
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
            isInside = false;
            tutorial.SetActive(false);

        }
    }

    public void Activate()
    {

        cameraController.FocusOn(focusPointIndex);
    }
}
