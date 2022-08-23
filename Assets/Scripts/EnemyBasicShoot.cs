using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicShoot : MonoBehaviour
{

    public float speed;
    private Transform player;
    public float range;
    public float rangeAttack;

    private float timeAttack = 0;
    public float attackRate = 2;
    public Animator anim;
    public BoxCollider2D body;
    public int damage;
    public SpriteRenderer sprite;

    public Sprite[] wearpon;
    private int randomWearpon;
    public SpriteRenderer weraponWear;

    public Transform startPoint;
    public bool isExit;
    public EnemyLife enemyLife;
    public GameObject enemy;


    private int velocityEnemy;
    public Transform pointOfShoot;
    public GameObject bullet;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // damage.SetActive(false);
        timeAttack = attackRate;
        randomWearpon = Random.Range(0, wearpon.Length);
        weraponWear.sprite = wearpon[randomWearpon];
        velocityEnemy = Random.Range(1, 4);
        speed = velocityEnemy;

    }



    // Update is called once per frame
    void Update()
    {
        if (enemyLife.currentHealth <= 0)
        {
            this.enabled = false;
            
            Destroy(enemy, 1f);
           
            EnemySpawnRoom.numOfEnemy --;
            EnemySpawnRoom.numOfEnemyFinal--;

        }

        if (isExit == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, startPoint.position, speed * Time.deltaTime);

        }
        if (transform.position.x == startPoint.position.x && transform.position.y == startPoint.position.y)
        {
            isExit = false;

        }

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

                Instantiate(bullet, pointOfShoot.transform.position, Quaternion.identity);
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
