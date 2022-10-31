using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject tarjet;
    public float speed;
    Rigidbody2D bulletRB;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
        bulletRB = GetComponent<Rigidbody2D>();
        tarjet = GameObject.FindGameObjectWithTag("Player");
        Vector2 moverDir = (tarjet.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector3(moverDir.x, moverDir.y, -90);
        Destroy(this.gameObject, 2);
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
                collision.gameObject.GetComponent<LifePlayer>().TakeDamage(damage);

            }
            Destroy(this.gameObject);
        }


    }
}
