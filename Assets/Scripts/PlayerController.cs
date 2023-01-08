using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    
    public float horizontalMove;

    public float verticalMove;

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


    //SHIELD
    public static bool isShieldActive = false;
    private float timeShield;
    public float durationShield;
    public GameObject shield;

    public GameObject panelArrow;
    public Text textArrow;
    public ShootPlayer shootPlayer;
   
    
   

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

        sliderChange.value = 0;

        shield.SetActive(false);
        timeShield = durationShield;

        panelArrow.SetActive(false);
        
    }



    private void FixedUpdate()
    {
        
    }

    



    // Update is called once per frame
    void Update()
    {

        textArrow.text = "" + shootPlayer.arrow;
        if (SkillTree.skillTree.skillLevels[1] >= SkillTree.skillTree.skillCaps[1])
        {
            panelArrow.SetActive(true);
        }


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



        if (SkillTree.skillTree.skillLevels[2] >= SkillTree.skillTree.skillCaps[2])
        {
            if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.JoystickButton4))
            {
                ActiveShield();
            }
            if (isShieldActive == true)
            {
                timeShield -= Time.deltaTime;
                if (timeShield <= 0)
                {
                    shield.SetActive(false);
                    isShieldActive = false;
                    Invoke("RestoreTimeShield", 3.7f);
                }
            }

            if (SkillTree.skillTree.skillLevels[4] >= 1 && SkillTree.skillTree.skillLevels[4] <= SkillTree.skillTree.skillCaps[4])
            {


                switch (SkillTree.skillTree.skillLevels[4])
                {
                    case 0:
                        durationShield = 2.5f;
                        break;
                    case 1:
                        durationShield = 3f;
                        break;

                    case 2:
                        durationShield = 3.5f;
                        break;

                    case 3:
                        durationShield = 4f;
                        break;

                    case 4:
                        durationShield = 4.5f;
                        break;

                    case 5:
                        durationShield = 5f;
                        break;

                    case 6:
                        durationShield = 5.5f;
                        break;

                    case 7:
                        durationShield = 6f;
                        break;

                    case 8:
                        durationShield = 6.5f;
                        break;
                }

            }
        }
            
       if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.JoystickButton1))
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
        
        if(ActiveShop.isShopEnabled== true)
        {
            speed = 0;
        }

        if (OpenAbilityTree.isEnabled == false)
        {
            speed = 0;
        }

        if(OpenMap.isActive == false)
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
            //attackPlayer.damage += 30;
            if (timePotion <= 0)
            {
                //attackPlayer.damage -= 30;
                PowerPotion.isPotionActive = false;
                timePotion = 0;
                potionSlider.SetActive(false);
                timePotion = timePotionDuration;
            }
        }
    }

    

    public void ActiveShield()
    {
        shield.SetActive(true);
        isShieldActive = true;
        
    }

    public void RestoreTimeShield()
    {
        timeShield = durationShield;
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
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.JoystickButton0))
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

        if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.JoystickButton0))
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
