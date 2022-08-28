using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDoorDeath : MonoBehaviour
{

    public bool isDeath;
    public EnemyLife enemyLife;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyLife.currentHealth <= 0)
        {
            isDeath = true;
        }
    }
}
