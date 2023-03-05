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
    public Points points;
    public XpTimer xpTimer;
    

    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(0, items.Length);
        currentHealth = maxHealth;
        randomSpawn = Random.Range(0, 5);
        points = GameObject.FindGameObjectWithTag("Player").GetComponent<Points>();
        xpTimer = GameObject.FindGameObjectWithTag("timer").GetComponent<XpTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            xpTimer.time -= 0.3f;
            points.SumarPuntos(Random.Range(0, 10));
            ModifyLayer.isDeleted = true;
            anim.Play("Death");
        }
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
