using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float speed;
    private Transform player;
    public float range;
    public float rangeAttack;
   
    private float nextFireTime;
    public float attackRate;
    public GameObject bullet;
    public GameObject bulletParent;

    public BoxCollider2D body;

    public SpriteRenderer sprite;
  
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // damage.SetActive(false);
        
    }

   

    // Update is called once per frame
    void Update()
    {

       

        float distance = Vector2.Distance(player.position, transform.position);
        if (distance < range && distance > rangeAttack)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);

        }
        else if (distance <= rangeAttack && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + attackRate;
                

        }

        chasePlayer();
        checkExit();
     
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

    public void checkExit()
    {
        if (CheckExit.isExit == true)
        {
            body.isTrigger = false;
        }
        else
        {
            body.isTrigger = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawWireSphere(transform.position, rangeAttack);
    }
}
