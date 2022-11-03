using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCoins : MonoBehaviour
{
    public ShopManagerScript shop;
    // Start is called before the first frame update
    void Start()
    {
        shop = FindObjectOfType<ShopManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Buy");
            shop.AddCoins(Random.Range(5, 20));
            Destroy(gameObject);
        }
    }
}
