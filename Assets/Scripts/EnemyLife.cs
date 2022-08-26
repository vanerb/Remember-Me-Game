using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    
    public GameObject[] items;
    private int random;
    public Transform startPoint;
    public Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(0, items.Length);
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            anim.Play("Death");
        }
       /* if (currentHealth >= 100)
        {
            currentHealth = maxHealth;
        }*/
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("La vida actual enemigo: " + currentHealth);
        anim.SetTrigger("Damage");
        if (currentHealth <= 0)
        {
            Instantiate(items[random], startPoint.transform.position, Quaternion.identity);
            //Destroy(this.gameObject);
            //Debug.Log("MUERTO");
        }
    }
}
