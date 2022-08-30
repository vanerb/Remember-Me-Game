using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePlayer : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject panelDeath;
    public static bool isDeath;
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        panelDeath.SetActive(false);
        isDeath = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth >= 100)
        {
            currentHealth = maxHealth;
        }
        
    }


    public void TakeDamage(int damage)
    {
        FindObjectOfType<AudioManager>().Play("PlayerHit");
        currentHealth -= damage;
        Debug.Log("La vida actual es de: " + currentHealth);
        healthBar.SetHealth(currentHealth);
        anim.Play("Hit");
        if (currentHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Stop("MainTheme");
            FindObjectOfType<AudioManager>().Play("GameOver");

            Invoke("ActivePane", 0.8f);
            Debug.Log("MUERTO");
            isDeath = true;
        }
    }

    public void TakeLife(int life)
    {
        FindObjectOfType<AudioManager>().Play("Life");
        
        currentHealth += life;
        Debug.Log("La vida actual es de: " + currentHealth);
        healthBar.SetHealth(currentHealth);
    }


    public void ActivePane()
    {
        panelDeath.SetActive(true);
        Time.timeScale = 0f;
    }

}
