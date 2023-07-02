using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBasicNavMesh : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject player;
    public GameObject startPoint;
    

    public Animator anim;

    //public bool isKick = false;

    public float rangeDetect;
    public float rangeAttack;

    public int randomSpeed;

    public Sprite[] wearpon;
    private int randomWearpon;
    public SpriteRenderer weraponWear;

    private float timeAttack = 0;
    public float attackRate = 2;

    public EnemyLife enemyLife;
    public GameObject enemy;
    public int damage;


    // Start is called before the first frame update
    void Start()
    {
        
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        randomSpeed = Random.Range(1, 6);
        navMeshAgent.speed = randomSpeed;
        randomWearpon = Random.Range(0, wearpon.Length);
        weraponWear.sprite = wearpon[randomWearpon];
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        CameraFollowObject cameraFollowObject = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<CameraFollowObject>();
        if (cameraFollowObject.isFocusing)
        {
            navMeshAgent.speed = 0;
            damage = 0;
        }
        else
        {
            navMeshAgent.speed = randomSpeed;
            damage = 10;
        }
       


        if (PotionInvisibility.isInvisibilityActive)
        {
            rangeDetect = 0f;
            rangeAttack = 0f;
        }
        else
        {
            rangeDetect = 6f;
            rangeAttack = 1.3f;
        }

        if (enemyLife.currentHealth <= 0)
        {
            this.enabled = false;

            navMeshAgent.speed = 0;
            Destroy(enemy, 1f);

            EnemySpawnRoom.numOfEnemy--;
            EnemySpawnRoom.numOfEnemyFinal--;
            BossTypeTwo.numSpawn--;
        }

        Chase();
        //float distance = Vector3.Distance(transform.position, destination.transform.position);
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance < rangeDetect && distance > rangeAttack)
        {

            navMeshAgent.destination = player.transform.position;

            anim.SetBool("isRun", true);
        }
        else if (distance <= rangeAttack)
        {
            navMeshAgent.velocity = Vector3.zero;
            anim.SetBool("isRun", false);
            //anim.Play("Punch");
            timeAttack -= Time.deltaTime;
            if (timeAttack <= 0)
            {
                anim.Play("Attack");
                FindObjectOfType<AudioManager>().Play("EnemyPunch");
                if (!PlayerController.isShieldActive)
                {
                    player.GetComponent<LifePlayer>().TakeDamage(damage);
                }
                
                timeAttack = attackRate;

            }


        }
        else
        {
            navMeshAgent.destination = startPoint.transform.position;
            anim.SetBool("isRun", false);
        }

        if (this.transform.position.x == startPoint.transform.position.x && this.transform.position.y == startPoint.transform.position.y)
        {
            anim.SetBool("isRun", false);
        }


    }



    void Chase()
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
        Gizmos.DrawWireSphere(transform.position, rangeDetect);
        Gizmos.DrawWireSphere(transform.position, rangeAttack);
    }
}
