using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject desactivate;
    public EnemyLife enemyLife;
    // Start is called before the first frame update
    void Start()
    {
        desactivate.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyLife.currentHealth < 50)
        {
            desactivate.SetActive(true);
        }
    }
}
