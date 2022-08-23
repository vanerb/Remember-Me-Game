using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampShoot : MonoBehaviour
{
    public float timeToShoot;
    private float time;
    
    public Transform shootPoint;
    public GameObject bullet;
    private bool isEntered = false;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        time = timeToShoot;
        isEntered = false;
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
                Instantiate(bullet, shootPoint.transform.position, Quaternion.identity);
                time = timeToShoot;

            }
        }
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
