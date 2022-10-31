using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossTypeTwo : MonoBehaviour
{
    //public float moveSpeed;
    //private bool moveRight;
    public Sprite[] wearpon;
    private int randomWearpon;
    public SpriteRenderer weraponWear;


    public Animator anim;

    
    private Transform player;
    public float range;
    public float rangeAttack;

    private float timeAttack = 0;
    public float attackRate = 2;

   
    public int damage;
    


    public Transform startPoint;

    public EnemyLife enemyLife;
    public GameObject enemy;

    public NavMeshAgent navMeshAgent;

    public int randomAttack;
    

    public Transform[] positions;
    public int posRandom;
    public ParticleSystem particleSystem;


    //SPAWNER

    public GameObject[] enemys;

    public Transform xRangeLeft;
    public Transform xRangeRight;
    public Transform yRangeUp;
    public Transform yRangeDown;

    public static int numSpawn;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        //moveRight = true;
        randomWearpon = Random.Range(0, wearpon.Length);
        weraponWear.sprite = wearpon[randomWearpon];

        player = GameObject.FindGameObjectWithTag("Player").transform;
        // damage.SetActive(false);
        timeAttack = attackRate;
        
        particleSystem.enableEmission = false;

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

        if (PotionInvisibility.isInvisibilityActive)
        {
            range = 0f;
            rangeAttack = 0f;
        }
        else
        {
            range = 5.5f;
            rangeAttack = 1f;
        }

        float distance = Vector2.Distance(player.position, transform.position);
        if (distance < range && distance > rangeAttack)
        {
            navMeshAgent.destination = player.transform.position;
            anim.SetBool("isRun", true);
            timeAttack -= Time.deltaTime;
        }
        else if (distance <= rangeAttack)
        {
            navMeshAgent.velocity = Vector3.zero;
            anim.SetBool("isRun", false);
            timeAttack -= Time.deltaTime;
            if (timeAttack <= 0)
            {
                randomAttack = Random.Range(0, 3);
                if (randomAttack == 0)
                {
                    FindObjectOfType<AudioManager>().Play("EnemyPunch");
                    anim.Play("Attack");
                    if (!PlayerController.isShieldActive)
                    {
                        player.GetComponent<LifePlayer>().TakeDamage(damage);
                    }
                    
                    timeAttack = attackRate;
                    
                    rangeAttack = 1.3f;


                }
                else if (randomAttack == 1)
                {
                    if (numSpawn < 3)
                    {
                        Vector3 spawnPos = new Vector3(0, 0, 0);

                        spawnPos = new Vector3(Random.Range(xRangeLeft.position.x, xRangeRight.position.x), Random.Range(yRangeUp.position.y, yRangeDown.position.y), 0);

                        GameObject enemy = Instantiate(enemys[Random.Range(0, enemys.Length)], spawnPos, gameObject.transform.rotation);

                        numSpawn++;
                        timeAttack = attackRate;
                        rangeAttack = 1.3f;
                    }
                   


                }

                else if (randomAttack == 2)
                {
                    FindObjectOfType<AudioManager>().Play("Disapear");
                    posRandom = Random.Range(0, positions.Length);
                    transform.position = new Vector3(positions[posRandom].transform.position.x, positions[posRandom].transform.position.y, 0);
                    timeAttack = attackRate;
                    rangeAttack = 1.3f;
                    particleSystem.enableEmission = true;
                    
                    Invoke("DissableEmission", 0.5f);
                }



            }

        }

        else
        {
            navMeshAgent.destination = startPoint.transform.position;
            anim.SetBool("isRun", false);
        }
        chasePlayer();

    }

    public void DissableEmission()
    {
        particleSystem.enableEmission = false;
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawWireSphere(transform.position, rangeAttack);
    }
}
