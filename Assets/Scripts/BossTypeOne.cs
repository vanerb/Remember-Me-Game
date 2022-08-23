using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTypeOne : MonoBehaviour
{

    //public float moveSpeed;
    //private bool moveRight;
    public Sprite[] wearpon;
    private int randomWearpon;
    public SpriteRenderer weraponWear;


    public Animator anim;

    public float speed;
    private Transform player;
    public float range;
    public float rangeAttack;

    private float timeAttack = 0;
    public float attackRate = 2;
   
    public BoxCollider2D body;
    public int damage;
    public SpriteRenderer sprite;


    public Transform startPoint;
    public bool isExit;
    public EnemyLife enemyLife;
    public GameObject enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        //moveRight = true;
        randomWearpon = Random.Range(0, wearpon.Length);
        weraponWear.sprite = wearpon[randomWearpon];

        player = GameObject.FindGameObjectWithTag("Player").transform;
        // damage.SetActive(false);
        timeAttack = attackRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyLife.currentHealth <= 0)
        {
            this.enabled = false;
            anim.Play("Death");
            Destroy(enemy, 2f);
            
        }

        if(isExit == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, startPoint.position, speed * Time.deltaTime);
            //anim.SetBool("isRun", true);
        }
        if(transform.position.x == startPoint.position.x && transform.position.y == startPoint.position.y)
        {
            isExit = false;
            //anim.SetBool("isRun", false);
        }
        /*if(transform.position.x > 7f)
        {
            moveRight = false;

        }
        else if(transform.position.x < -7f){
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);

        }*/

        float distance = Vector2.Distance(player.position, transform.position);
        if (distance < range && distance > rangeAttack && isExit == false)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            anim.SetBool("isRun", true);
        }
        else if (distance <= rangeAttack && isExit == false)
        {

            anim.SetBool("isRun", false);
            timeAttack -= Time.deltaTime;
            if (timeAttack <= 0)
            {
                anim.Play("Attack");

                player.GetComponent<LifePlayer>().TakeDamage(damage);
                timeAttack = attackRate;

            }

        }
        
        else
        {
            anim.SetBool("isRun", false);
        }
        chasePlayer();

    }

   

    public void chasePlayer()
    {
        if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Exit"))
        {
            isExit = true;
        }
    }

  



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawWireSphere(transform.position, rangeAttack);
    }
}
