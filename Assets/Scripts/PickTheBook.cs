using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickTheBook : MonoBehaviour
{
    private BookStorage bookStorage;
    public GameObject itemButton;
    // Start is called before the first frame update
    void Start()
    {
        bookStorage = GameObject.FindGameObjectWithTag("Player").GetComponent<BookStorage>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < bookStorage.slots.Length; i++)
            {
                if (bookStorage.isFull[i] == false)
                {
                    FindObjectOfType<AudioManager>().Play("PickItem");
                    //ITEM ADDED;
                    bookStorage.isFull[i] = true;
                    Instantiate(itemButton, bookStorage.slots[i].transform, false);

                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
