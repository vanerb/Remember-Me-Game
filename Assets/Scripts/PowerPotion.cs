using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPotion : MonoBehaviour
{
    public static bool isPotionActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Function()
    {
        isPotionActive = true;
        if (isActiveAndEnabled == true)
        {
            Destroy(this.gameObject);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            
        }
    }*/

}
