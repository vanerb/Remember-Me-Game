using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyLayerENemy : MonoBehaviour
{
    public SpriteRenderer enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            enemy.sortingOrder = -2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            enemy.sortingOrder = 6;
        }
    }
}
