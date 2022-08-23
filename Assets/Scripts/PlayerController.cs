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

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        timeRun = RunTime;
        barRun.maxValue = timeRun;
        bar.SetActive(false);
        changeLife.SetMaxHealth(50);
        timePotion = timePotionDuration;
        potionPowerSlider.maxValue = timePotion;
        potionSlider.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        
        rb2d.velocity = new Vector2(horizontalMove * speed, verticalMove * speed);
        
        ChasePlayer();

        velocityPlayer();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeLifePlayer();
        }
        changeLife.SetHealth(TakeLife.pickObject);
        
        Potion();
    }

    public void Potion()
    {
        if(PowerPotion.isPotionActive == true)
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
       
        if(TakeLife.pickObject >= 5)
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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            bar.SetActive(true);
            timeRun -= Time.deltaTime;
            barRun.value = timeRun;
            if (timeRun <= 0)
            {
                
                bar.SetActive(false);
                speed = 3f;
                timeRun = 0;

            }
            else
            {
               
                speed = 5;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            bar.SetActive(false);
            speed = 3f;
            
            timeRun = RunTime;
            

        }

    }


    public void ChasePlayer()
    {
        if(horizontalMove > 0)
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
