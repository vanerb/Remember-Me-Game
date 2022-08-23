using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearponsManager : MonoBehaviour
{
    public static int wearponSelect;
    public AttackPlayer attackSword;
    public ShootPlayer bowPlayer;
    public GameObject swordWearpon;
    public GameObject BowGameObject;

    // Start is called before the first frame update
    void Start()
    {
        wearponSelect = 1;
        attackSword.enabled = true;
        bowPlayer.enabled = false;
        swordWearpon.SetActive(true);
        BowGameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            wearponSelect = 1;
            attackSword.enabled = true;
            bowPlayer.enabled = false;
            swordWearpon.SetActive(true);
            BowGameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            wearponSelect = 2;
            attackSword.enabled = false;
            bowPlayer.enabled = true;
            swordWearpon.SetActive(false);
            BowGameObject.SetActive(true);
        }
    }
}
