using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvisibilityActive : MonoBehaviour
{
    public SpriteRenderer[] playerRender;

    //SLIDER 

    public Slider sliderInvis;
    public GameObject invsSlider;
    public float timeInvisibility;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        invsSlider.SetActive(false);
        sliderInvis.maxValue = 6f;

        time = timeInvisibility;
    }

    // Update is called once per frame
    void Update()
    {
        sliderInvis.value = time;
       if (PotionInvisibility.isInvisibilityActive)
       {
            invsSlider.SetActive(true);
            time -= Time.deltaTime;
            playerRender[0].color = new Color(1, 1, 1, 0.3f);
            playerRender[1].color = new Color(1, 1, 1, 0.3f);
            playerRender[2].color = new Color(1, 1, 1, 0.3f);
            playerRender[3].color = new Color(1, 1, 1, 0.3f);
            playerRender[4].color = new Color(1, 1, 1, 0.3f);
            if (time <= 0)
            {
                time = timeInvisibility;
                SetNormalAtrib();

            }
           
        }
       
        }
       
    

    public void SetNormalAtrib()
    {
        invsSlider.SetActive(false);
        PotionInvisibility.isInvisibilityActive = false;
        playerRender[0].color = new Color(1, 1, 1, 1f);
        playerRender[1].color = new Color(1, 1, 1, 1f);
        playerRender[2].color = new Color(1, 1, 1, 1f);
        playerRender[3].color = new Color(1, 1, 1, 1f);
        playerRender[4].color = new Color(1, 1, 1, 1f);
    }
}
