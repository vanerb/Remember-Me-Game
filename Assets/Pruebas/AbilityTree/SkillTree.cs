using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{

    public static SkillTree skillTree;
    public int[] skillLevels;
    public int[] skillCaps;
    public string[] skillNames;
    public string[] skilDescription;

    public string[] skillNamesEn;
    public string[] skilDescriptionEn;

    public List<Skill> skillsList;

    public GameObject skillHolder;
    public int skillPoint;
    public List<GameObject> connectionList;
    public GameObject connectionHolder;
    public int pointstotal;

    
    private void Awake() => skillTree = this;
   
    // Start is called before the first frame update
    void Start()
    {
        
        skillPoint =  0;
        skillLevels = new int[7];
        skillCaps = new[] { 1, 1, 1, 1, 8, 10, 9 };
        skillNames = new[] { "Mejora Espada", "Arco", "Escudo", "Espada Legendaria", "Duración escudo", "Aumento daño" , "Aumento vida"};
        skillNamesEn = new[] { "Sword Upgrade", "Bow", "Shield", "Legendary Sword", "Shield Duration", "Damage Increase", "Health Increase" };
        skilDescription = new[] { "Repara la espada equipada para hacer más daño", "Equípate con un arco y flechas", "Equípate con un escudo que te ayudará a defenderte de los enemigos", "Equípate con una espada legendaria que te proporcionará mucho márgen de mejora", "Aumenta el tiempo en el que puedes tener protección con el escudo", "Aumenta tu fuerza y por lo tanto tu daño con la espada", "Aumenta tu barra de vida"};
        skilDescriptionEn = new[] { "Repair the equipped sword to deal more damage", "Equip yourself with a bow and arrows", "Equip yourself with a shield that will help you defend against enemies", "Equip yourself with a legendary sword that will provide you with a lot of room for improvement", "Increase the time you can have protection with the shield", "Increase your strength and therefore your damage with the sword", "Increase your health bar" };

        foreach (var skill in skillHolder.GetComponentsInChildren<Skill>()) 
        {
            skillsList.Add(skill);
        }
        foreach (var connector in connectionHolder.GetComponentsInChildren<RectTransform>())
        {
            connectionList.Add(connector.gameObject);
        }

        for (var i = 0; i < skillsList.Count; i++)
        {
            skillsList[i].id = i;
        }


        skillsList[0].connectedUpgrades = new[] { 1, 2, 3 };
        skillsList[2].connectedUpgrades = new[] { 4};
        skillsList[3].connectedUpgrades = new[] { 5 , 6};
        UpdateAllSkillUi();
    }
    

    public void UpdateAllSkillUi()
    {
        
        foreach (var skill in skillsList) skill.UpdateUI();
    }

   
}
