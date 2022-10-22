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
    private int randomSpawn;
    

    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(0, items.Length);
        currentHealth = maxHealth;
        randomSpawn = Random.Range(0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            ModifyLayer.isDeleted = true;
            anim.Play("Death");
        }
       /* if (currentHealth >= 100)
        {
            currentHealth = maxHealth;
        }*/
    }

    public void TakeDamage(int damage)
    {
        FindObjectOfType<AudioManager>().Play("EnemyHit");
        currentHealth -= damage;
        Debug.Log("La vida actual enemigo: " + currentHealth);
        anim.SetTrigger("Damage");
        if (currentHealth <= 0 && randomSpawn == 2)
        {
            Instantiate(items[random], startPoint.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Debug.Log("MUERTO");
        }
    }
}
