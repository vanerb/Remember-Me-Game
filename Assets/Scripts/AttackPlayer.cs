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


    public Sprite sword;
    public SpriteRenderer swordSprite;
    public Sprite swordlegendary;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SkillTree.skillTree.skillLevels[0] >= SkillTree.skillTree.skillCaps[0])
        {
            swordSprite.sprite = sword;
            damage = 20;
        }
        

        if (SkillTree.skillTree.skillLevels[3] >= SkillTree.skillTree.skillCaps[3])
        {
            swordSprite.sprite = swordlegendary;
            damage = 25;
        }

        if (SkillTree.skillTree.skillLevels[5] >= 1 && SkillTree.skillTree.skillLevels[5] <= SkillTree.skillTree.skillCaps[5])
        {
            switch (SkillTree.skillTree.skillLevels[5])
            {
                case 0:
                    damage = 22;
                    break;
                case 1:
                    damage = 24;
                    break;

                case 2:
                    damage = 26;
                    break;

                case 3:
                    damage = 28;
                    break;

                case 4:
                    damage = 30;
                    break;

                case 5:
                    damage = 32;
                    break;

                case 6:
                    damage = 34;
                    break;

                case 7:
                    damage = 36;
                    break;

                case 8:
                    damage = 38;
                    break;
                case 9:
                    damage = 40;
                    break;

                case 10:
                    damage = 42;
                    break;
            }
        }


        if (Time.time >= nextAttack)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                Attack();
                nextAttack = Time.time + 1f / attackRate;

            }
        }

    }


    void Attack()
    {
        anim.SetTrigger("Attack");
        FindObjectOfType<AudioManager>().Play("Attack");

        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemy)
        {
            //Camera.main.GetComponent<CameraFollow>().ShakeCamera(0.1f, 0.1f);
            if (PowerPotion.isPotionActive == true)
            {
                enemy.GetComponent<EnemyLife>().TakeDamage(damage+30);
            }
            else
            {
                enemy.GetComponent<EnemyLife>().TakeDamage(damage);

            }
            EnemyController enemyController = enemy.gameObject.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                Vector2 direction = enemy.transform.position - transform.position;
                enemyController.ApplyForce(direction.normalized * 1.5f);
            }
            Debug.Log("ATACANDO");
        }
       
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
