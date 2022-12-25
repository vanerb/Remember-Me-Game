using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManagerScript : MonoBehaviour
{
    public int coins;
    public Text coinsTxt;
    public ButtonInfo[] shopitemSO;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] purchaseButs;
    public GameObject[] objects;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < shopitemSO.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
        }
        coinsTxt.text = "Monedas: " + coins.ToString();
        LoadPanels();
        CheckPurchaseable();
    }

    public void Buy()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPanels()
    {
        
        for (int i = 0; i < shopitemSO.Length; i++)
        {
            shopPanels[i].title.text = shopitemSO[i].title;
            shopPanels[i].description.text = shopitemSO[i].description;
            shopPanels[i].baseCost.text = shopitemSO[i].baseCost.ToString();
        }
    }



    public void AddCoins(int coin)
    {
        coins += coin;
        coinsTxt.text = "Monedas: " + coins.ToString();
        CheckPurchaseable();
    }

    public void CheckPurchaseable()
    {
        
        for(int i = 0; i < shopitemSO.Length; i++)
        {
            if(coins>= shopitemSO[i].baseCost)
            {
                
                purchaseButs[i].interactable = true;
            }
            else
            {
                purchaseButs[i].interactable = false;
            }
        }
    }

    public void PurchaseItem(int btNo)
    {
        if (coins >= shopitemSO[btNo].baseCost)
        {
            coins = coins - shopitemSO[btNo].baseCost;
            coinsTxt.text = "Monedas: " + coins.ToString();
            
            CheckPurchaseable();
            //ITEM;
            if(shopitemSO[btNo].title.ToLower() == "didoxain")
            {
                Instantiate(objects[0], player.transform.position, Quaternion.identity);
            }
            else if(shopitemSO[btNo].title.ToLower() == "agony seed")
            {
                Instantiate(objects[2], player.transform.position, Quaternion.identity);
            }
            else if(shopitemSO[btNo].title.ToLower() == "keacan")
            {
                Instantiate(objects[1], player.transform.position, Quaternion.identity);
            }
            else if (shopitemSO[btNo].title.ToLower() == "wraith tears")
            {
                Instantiate(objects[3], player.transform.position, Quaternion.identity);
            }
        }
    }
}
