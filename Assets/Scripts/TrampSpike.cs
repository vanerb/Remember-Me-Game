using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampSpike : MonoBehaviour
{
    public float timeAttack;
    private float time;
    public int damage;
    public bool isDamage = false;
    public Animator anim;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        time = timeAttack;
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDamage == true)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                anim.Play("Activate");
                player.gameObject.GetComponent<LifePlayer>().TakeDamage(damage);
                time = timeAttack;
            }
            
            
        }
        
    }


   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDamage = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDamage = false;
        }
    }
}
