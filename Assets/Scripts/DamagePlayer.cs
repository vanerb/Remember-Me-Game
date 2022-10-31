using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private Transform player;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!PlayerController.isShieldActive)
            {
                player.GetComponent<LifePlayer>().TakeDamage(damage);
            }
            
            Debug.Log("HERDO");
        }
    }
}
