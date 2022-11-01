using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoisonActive : MonoBehaviour
{

    

    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayer;

    public float attackRate = 2f;
    float nextAttack;
    public int damage;
    public GameObject ilum;

    //AÑADIDO BARRA VISUAL

    public Slider sliderPoison;
    public GameObject poisonSlider;
    public float timePoison;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        ilum.SetActive(false);
        poisonSlider.SetActive(false);
        sliderPoison.maxValue = 10f;
       
        time = timePoison;
        
    }

    // Update is called once per frame
    void Update()
    {
        Poison();
        
        
    }
    public void Poison()
    {
        sliderPoison.value = time;
        if (PotionPoison.isPoisonActive == true)
        {
            poisonSlider.SetActive(true);
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = timePoison;
                DisablePoison();

            }


            if (Time.time >= nextAttack) { 
                Attack();
                ilum.SetActive(true);
                nextAttack = Time.time + 1f / attackRate;
            }
        }
    }

    public void DisablePoison()
    {
        poisonSlider.SetActive(false);
        ilum.SetActive(false);
        PotionPoison.isPoisonActive = false;
    }

    void Attack()
    {
       //anim.SetTrigger("Attack");
        FindObjectOfType<AudioManager>().Play("EnemyHit");

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
