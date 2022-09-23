using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyLayer : MonoBehaviour
{
    public SpriteRenderer objectToModify;
    public SpriteRenderer sword;
    public SpriteRenderer hand;
    public SpriteRenderer bow;
    public int layerInt;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ColArm"))
        {
            objectToModify.sortingOrder = layerInt;
            sword.sortingOrder = layerInt;
            hand.sortingOrder = layerInt;
            bow.sortingOrder = layerInt;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ColArm"))
        {
            objectToModify.sortingOrder = 12;
            sword.sortingOrder = 10;
            hand.sortingOrder = 11;
            bow.sortingOrder = 10;
        }
    }
}
