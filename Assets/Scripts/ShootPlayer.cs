using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootPlayer : MonoBehaviour
{

    public Animator anim;
    private float nextFireTime;
    public float attackRate;
    public GameObject bullet;
    public GameObject bulletParent;


    public int arrow;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (SkillTree.skillTree.skillLevels[1] >= SkillTree.skillTree.skillCaps[1])
        {
            
            if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.JoystickButton5))
            {
                if (arrow > 0)
                {
                    if (nextFireTime < Time.time)
                    {
                        FindObjectOfType<AudioManager>().Play("Flecha");
                        anim.Play("ShootPlayer");
                        Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
                        nextFireTime = Time.time + attackRate;
                        arrow--;
                    }
                }
                

            }
        }
    }
        
        
        
 }

   
    

