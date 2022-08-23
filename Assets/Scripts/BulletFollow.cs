using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollow : MonoBehaviour
{
    Transform tarjet;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
        tarjet = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(this.gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, tarjet.position, speed * Time.deltaTime);
    }
}
