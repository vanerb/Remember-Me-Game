using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibilityActive : MonoBehaviour
{
    public SpriteRenderer[] playerRender;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            
       if (PotionInvisibility.isInvisibilityActive)
       {
            playerRender[0].color = new Color(1, 1, 1, 0.3f);
            playerRender[1].color = new Color(1, 1, 1, 0.3f);
            playerRender[2].color = new Color(1, 1, 1, 0.3f);
            playerRender[3].color = new Color(1, 1, 1, 0.3f);
            playerRender[4].color = new Color(1, 1, 1, 0.3f);
        }
       else
       {
            playerRender[0].color = new Color(1, 1, 1, 1f);
            playerRender[1].color = new Color(1, 1, 1, 1f);
            playerRender[2].color = new Color(1, 1, 1, 1f);
            playerRender[3].color = new Color(1, 1, 1, 1f);
            playerRender[4].color = new Color(1, 1, 1, 1f);
        }
            
            
            Invoke("SetNormalAtrib", 8f);
        }
       
    

    public void SetNormalAtrib()
    {
        PotionInvisibility.isInvisibilityActive = false;
    }
}
