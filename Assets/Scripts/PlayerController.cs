using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    
    private float horizontalMove;

    private float verticalMove;

    private Rigidbody2D rb2d;

    public float speed;

    public Animator anim;

    
    
    private float timeRun;
    public float RunTime;

    public Slider barRun;
    public GameObject bar;


    public LifePlayer lifePlayer;
    //public Slider barLife;
    public int lifeInt;

    public Slider potionPowerSlider;
    public float timePotion;
    public float timePotionDuration;
    public AttackPlayer attackPlayer;
    public GameObject potionSlider;

    public static float cant;

    public ChangeLife changeLife;

    public bool isNotRun = false;

    public ParticleSystem particleSystem;

    public Slider sliderChange;

    
   

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        timeRun = RunTime;
        barRun.maxValue = timeRun;
        barRun.value = timeRun;
        //bar.SetActive(false);
        changeLife.SetMaxHealth(50);
        timePotion = timePotionDuration;
        potionPowerSlider.maxValue = timePotion;
        potionSlider.SetActive(false);
        isNotRun = false;
        particleSystem.enableEmission = false;

        

    }

  

    

    // Update is called once per frame
    void Update()
    {
        if (lifePlayer.currentHealth <= 0)
        {
            anim.Play("Death");
            this.enabled = false;
            speed = 0;
        }

        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        
        rb2d.velocity = new Vector2(horizontalMove * speed, verticalMove * speed);
        
        ChasePlayer();

        velocityPlayer();

       
        changeLife.SetHealth(TakeLife.pickObject);

            
       if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button1))
       {
         TakeLifePlayer();
       }

       
       if(TakeLife.pickObject > sliderChange.maxValue)
        {
            TakeLife.pickObject = 50;
        }

        Potion();

        if(OpenInventory.isActive == false)
        {
            speed = 0;
        }

        if(OpenBook.isBookEnabled == false)
        {
            speed = 0;
        }

        if(OpenStorageBook.isActive == false)
        {
            speed = 0;
        }

        if (ActiveSheet.isActive == true)
        {
            speed = 0;
        }

    }

    public void Potion()
    {
        
        if (PowerPotion.isPotionActive == true)
        {
            
            potionSlider.SetActive(true);
            potionPowerSlider.value = timePotion;
            timePotion -= Time.deltaTime;
            attackPlayer.damage = 40;
            if (timePotion <= 0)
            {
                
                PowerPotion.isPotionActive = false;
                timePotion = 0;
                potionSlider.SetActive(false);
                timePotion = timePotionDuration;
            }
        }
    }

    public void TakeLifePlayer()
    {
        
        if (TakeLife.pickObject >= 5)
        {
            if(lifePlayer.currentHealth < 100)
            {
                
                lifePlayer.TakeLife(lifeInt);
                TakeLife.pickObject -= 5;
                
            }
        }
    }

   

    public void velocityPlayer()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Joystick1Button0))
        {
            isNotRun = true;
            //bar.SetActive(true);
            
            if (timeRun <= 0)
            {
                isNotRun = false;
                //bar.SetActive(false);
                speed = 3f;
                timeRun = 0;
                particleSystem.enableEmission = false;
                barRun.value += 0.01f;
                if (barRun.value == barRun.maxValue)
                {
                    timeRun = RunTime;
                    isNotRun = true;
                }
            }
            
            else
            {
                if (isNotRun == true)
                {
                    timeRun -= Time.deltaTime;
                    barRun.value = timeRun;
                    particleSystem.enableEmission = true;
                    if (transform.localScale.x == -1)
                    {
                        particleSystem.transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else
                    {
                        particleSystem.transform.localScale = new Vector3(1, 1, 1);
                    }
                    speed = 5;
                }

            }
        }

        if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Joystick1Button0))
        {
            isNotRun = false;
            //bar.SetActive(false);
            speed = 3f;
            timeRun = 0;
            particleSystem.enableEmission = false;
            barRun.value += 0.01f;
            if (barRun.value == barRun.maxValue)
            {
                timeRun = RunTime;
                isNotRun = true;
            }

        }

        /*  if (!Input.GetKey(KeyCode.LeftShift))
          {
              // bar.SetActive(false);
              speed = 3f;
              particleSystem.enableEmission = false;

              if (barRun.value <= RunTime)
              {
                  //isNotRun = false;
                  barRun.value += 0.01f;
                  if(barRun.value == barRun.maxValue)
                  {
                      timeRun = RunTime;
                      //isNotRun = true;
                  }

              }

          }*/


    }


    public void ChasePlayer()
    {
        
        if (horizontalMove > 0)
        {
            
            anim.SetBool("isRun", true);
            transform.localScale = new Vector3(1, 1, 1);
            BulletPlayer.isRotated = false;
        }
        else if (horizontalMove < 0)
        {
            
            anim.SetBool("isRun", true);
            transform.localScale = new Vector3(-1, 1, 1);
            BulletPlayer.isRotated = true;
        }
        else if (verticalMove < 0)
        {
            anim.SetBool("isRun", true);
        }
        else if (verticalMove > 0)
        {
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
    }
}
