using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "ShopMenu", menuName = "Scrip Object", order = 1)]
public class ButtonInfo : ScriptableObject
{

    public string title;
    public string description;
    public int baseCost;
}
