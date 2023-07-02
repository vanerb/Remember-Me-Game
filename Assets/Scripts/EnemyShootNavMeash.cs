using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShootNavMeash : MonoBehaviour
{
    
    private Transform player;
    public float range;
    public float rangeAttack;

    private float timeAttack = 0;
    public float attackRate = 2;
    public Animator anim;
   
    //public int damage;
    

    public Sprite[] wearpon;
    private int randomWearpon;
    public SpriteRenderer weraponWear;

    public Transform startPoint;
   
    public EnemyLife enemyLife;
    public GameObject enemy;


    private int velocityEnemy;
    public Transform pointOfShoot;
    public GameObject bullet;


    public NavMeshAgent navMeshAgent;

    public float randomAttackRange;
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // damage.SetActive(false);
        timeAttack = attackRate;
        randomWearpon = Random.Range(0, wearpon.Length);
        weraponWear.sprite = wearpon[randomWearpon];
        velocityEnemy = Random.Range(1, 6);
        randomAttackRange = Random.Range(2, 3);

        rangeAttack = randomAttackRange;

        navMeshAgent.speed = velocityEnemy;
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;

    }



    // Update is called once per frame
    void Update()
    {

        CameraFollowObject cameraFollowObject = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<CameraFollowObject>();
        if (cameraFollowObject.isFocusing)
        {
            navMeshAgent.speed = 0;
            rangeAttack = 0;

            
        }
        else
        {
            navMeshAgent.speed = velocityEnemy;
            rangeAttack = randomAttackRange;
        }

        if (PotionInvisibility.isInvisibilityActive)
        {
            range = 0f;
            rangeAttack = 0f;
        }
        else
        {
            range = 6f;
            rangeAttack = 2.5f;
        }


        if (enemyLife.currentHealth <= 0)
        {
            this.enabled = false;
            navMeshAgent.speed = 0;
            Destroy(enemy, 1f);

            EnemySpawnRoom.numOfEnemy--;
            EnemySpawnRoom.numOfEnemyFinal--;

        }

        float distance = Vector2.Distance(player.position, transform.position);
        if (distance < range && distance > rangeAttack)
        {
            navMeshAgent.destination = player.transform.position;
            anim.SetBool("isRun", true);
        }
        else if (distance <= rangeAttack)
        {
            navMeshAgent.velocity = Vector3.zero;
            anim.SetBool("isRun", false);
            timeAttack -= Time.deltaTime;
            if (timeAttack <= 0)
            {
                anim.Play("Attack");
                FindObjectOfType<AudioManager>().Play("EnemyShoot");
                Instantiate(bullet, pointOfShoot.transform.position, Quaternion.identity);
                timeAttack = attackRate;

            }

        }
        else
        {
            navMeshAgent.destination = startPoint.transform.position;
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


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawWireSphere(transform.position, rangeAttack);
    }
}
