using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonActive : MonoBehaviour
{

    

    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayer;

    public float attackRate = 2f;
    float nextAttack;
    public int damage;
    public GameObject ilum;


    // Start is called before the first frame update
    void Start()
    {
        ilum.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Poison();
    }

    public void Poison()
    {
        
        if (PotionPoison.isPoisonActive == true)
        {
            if (Time.time >= nextAttack) { 
                Attack();
                ilum.SetActive(true);
                Invoke("DisablePoison", 10f);
                nextAttack = Time.time + 1f / attackRate;
            }
        }
    }

    public void DisablePoison()
    {
        ilum.SetActive(false);
        PotionPoison.isPoisonActive = false;
    }

    void Attack()
    {
       //anim.SetTrigger("Attack");
        FindObjectOfType<AudioManager>().Play("Attack");

        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemy)
        {
            enemy.GetComponent<EnemyLife>().TakeDamage(damage);

            Debug.Log("ATACANDO");
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
