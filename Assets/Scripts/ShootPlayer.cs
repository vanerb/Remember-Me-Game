using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{

    public Animator anim;
    private float nextFireTime;
    public float attackRate;
    public GameObject bullet;
    public GameObject bulletParent;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1) && nextFireTime < Time.time)
        {
            FindObjectOfType<AudioManager>().Play("Flecha");
            anim.Play("ShootPlayer");
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + attackRate;
        }

        
        
        
    }

   
    
}
