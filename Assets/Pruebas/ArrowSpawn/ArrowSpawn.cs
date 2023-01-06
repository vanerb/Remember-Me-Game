using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    public ShootPlayer attackPlayer;
    public int arrowsum;
    // Start is called before the first frame update
    void Start()
    {
        attackPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            arrowsum = Random.Range(5, 20);
            attackPlayer.arrow += arrowsum;
            Destroy(this.gameObject);
        }
    }
}
