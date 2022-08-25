using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBasicNavMesh : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject player;
    public GameObject startPoint;
    

    public Animator anim;

    //public bool isKick = false;

    public float rangeDetect;
    public float rangeAttack;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
        //float distance = Vector3.Distance(transform.position, destination.transform.position);
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance < rangeDetect && distance > rangeAttack)
        {
            navMeshAgent.destination = player.transform.position;

            anim.SetBool("isRun", true);
        }
        else if (distance <= rangeAttack)
        {
            navMeshAgent.velocity = Vector3.zero;
            anim.SetBool("isRun", false);
            //anim.Play("Punch");


        }
        else
        {
            navMeshAgent.destination = startPoint.transform.position;
        }

        if (this.transform.position.x == startPoint.transform.position.x && this.transform.position.y == startPoint.transform.position.y)
        {
            anim.SetBool("isRun", false);
        }


    }



    void Chase()
    {
        if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }
    }
}
