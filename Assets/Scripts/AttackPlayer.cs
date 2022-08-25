using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{

    public Animator anim;

    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayer;

    public float attackRate = 2f;
    float nextAttack;
    public int damage;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttack)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttack = Time.time + 1f / attackRate;
            }
        }
        
    }


    void Attack()
    {
        anim.SetTrigger("Attack");


       Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in hitEnemy)
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
