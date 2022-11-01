using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionInvisibility : MonoBehaviour
{
    public static bool isInvisibilityActive = false;
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
        

    }

    public void Function()
    {
        if(!PotionPoison.isPoisonActive && !PowerPotion.isPotionActive)
        {
            FindObjectOfType<AudioManager>().Play("Power");
            isInvisibilityActive = true;
            if (isActiveAndEnabled == true)
            {
                Destroy(this.gameObject);
            }
        }
        
    }
}
