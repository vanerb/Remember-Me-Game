using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeLife : MonoBehaviour
{

    
    private int random;
    //private Transform player;
    public static int pickObject;

    
    public int lifes;
    
    // Start is called before the first frame update
    void Start()
    {
       // player = GameObject.FindGameObjectWithTag("Player").transform;
        random = Random.Range(5, 20);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Function()
    {

        pickObject += random;
        //player.GetComponent<LifePlayer>().TakeLife(random);
        FindObjectOfType<AudioManager>().Play("Use");
        Destroy(this.gameObject);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        }
    }*/
}
