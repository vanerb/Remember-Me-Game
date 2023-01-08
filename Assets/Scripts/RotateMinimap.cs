using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMinimap : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.horizontalMove > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0,0,-90));
        }

        else if (playerController.horizontalMove < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        
        if (playerController.verticalMove > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        }
        else if(playerController.verticalMove < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -180));

        }
    }
}
