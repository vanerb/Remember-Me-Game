using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
   
    public float speed;
    public Rigidbody2D bulletRB;
    public int damage;
    public Transform player;
    public static bool isRotated = false;
    public SpriteRenderer sprite;

    public static bool isHitted;

    // Start is called before the first frame update
    void Start()
    {
        
       if(isRotated == false)
        {
            bulletRB.velocity = transform.right * speed;
            sprite.flipX = false;
        }
        else
        {
            bulletRB.velocity = transform.right * -speed;
            sprite.flipX = true;
        }
        
        
        
        Destroy(this.gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyLife>().TakeDamage(damage);
            isHitted = true;
            Destroy(this.gameObject);

        }
        else
        {
            isHitted = false;
        }
        //if (collision.CompareTag("Wall"))
        //{
        //    Destroy(this.gameObject);
        //}
    }

}
