using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRect : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb2d;
    public Transform tarjet;
    public float timeToDestroy = 3f;
    


    //1=Arriba 2=Abajo 3=derecha 4=izquierda
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        rb2d.velocity = transform.up * -speed;
        
       
        Destroy(this.gameObject, timeToDestroy);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
