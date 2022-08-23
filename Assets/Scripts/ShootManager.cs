using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public FIreBullets fire;
    public EnemyLife enemyLife;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyLife.currentHealth <= 100)
        {
            fire.bulletAmount = 8;
            fire.startAngle = 0;
            fire.endAngle = 180;
            fire.repeatTime = 5;
        }

        if (enemyLife.currentHealth <= 50)
        {
            fire.bulletAmount = 12;
            fire.startAngle = 0;
            fire.endAngle = 270;
            fire.repeatTime = 3;
        }

        if (enemyLife.currentHealth <= 30)
        {
            fire.bulletAmount = 16;
            fire.startAngle = 0;
            fire.endAngle = 360;
            fire.repeatTime = 1;
        }

    }
}
