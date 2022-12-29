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
        
        skillPoint = 0;
        skillLevels = new int[7];
        skillCaps = new[] { 1, 1, 1, 1, 8, 10, 9 };
        skillNames = new[] { "Mejora Espada", "Arco", "Escudo", "Espada Legendaria", "Duracion escudo", "Aumento daño" , "Aumento vida"};
        skilDescription = new[] { "Repara la espada equipada para hacer mas daño", "Equipate con un arco y flechas", "Equipate con un escudo que te ayudara a defenderte de los enemigos", "Equipate con una espada legendaria que te proporcionara mucho margen de mejora", "Aumenta el tiempo en el que puedes tener proteccion con el escudo", "Aumenta tu fuerza y por lo tanto tu daño con la espada", "Aumenta tu barra de vida"};
        

        foreach(var skill in skillHolder.GetComponentsInChildren<Skill>()) 
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
