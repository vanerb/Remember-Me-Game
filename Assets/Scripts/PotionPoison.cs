using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPoison : MonoBehaviour
{
    public static bool isPoisonActive = false;
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
        /*if (collision.CompareTag("Player"))
        {
            Function();
        }*/
        
    }

    public void Function()
    {
        if(!PowerPotion.isPotionActive && !PotionInvisibility.isInvisibilityActive)
        {
            FindObjectOfType<AudioManager>().Play("Power");
            isPoisonActive = true;
            if (isActiveAndEnabled == true)
            {
                Destroy(this.gameObject);
            }
        }
        
    }
}
