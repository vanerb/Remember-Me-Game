using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnRoom : MonoBehaviour
{
    public bool isInRoom = false;
    public GameObject[] enemys;
    public Transform xRangeLeft;
    public Transform xRangeRight;
    public Transform yRangeUp;
    public Transform yRangeDown;
    private int enemyRandom;
    public static int numOfEnemy = 0;
    private int numberEnemysLimit = 0;
    public BoxCollider2D BoxCollider2D;
    public static int numOfEnemyFinal = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        isInRoom = false;
        numOfEnemy = 0;
        numberEnemysLimit = 0;
        numberEnemysLimit = Random.Range(2, 5);
        numOfEnemyFinal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("El numero de enemigos es de: "+numOfEnemyFinal);
        if(numOfEnemyFinal<=0){
            BoxCollider2D.enabled = true;
            numOfEnemy = 0;
        }
        if(isInRoom == true)
        {
            numOfEnemy++;
            enemyRandom = Random.Range(0, enemys.Length);
            numberEnemysLimit = Random.Range(1, 5);
            Vector3 spawnPos = new Vector3(0, 0, 0);
            
            spawnPos = new Vector3(Random.Range(xRangeLeft.position.x, xRangeRight.position.x), Random.Range(yRangeUp.position.y, yRangeDown.position.y), 0);
            Instantiate(enemys[enemyRandom], spawnPos, gameObject.transform.rotation);
            numOfEnemyFinal ++;
            //BoxCollider2D.enabled = false;
            if (numOfEnemy > numberEnemysLimit){
                isInRoom = false;
                BoxCollider2D.enabled = false;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            isInRoom = true;
            numOfEnemy = 0;
           
        }
    }
   
    
}
