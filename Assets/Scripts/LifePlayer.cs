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
    public AudioSource mainTheme;
    public int muertesTotal;
    public GameObject[] lifes;
    
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
            currentHealth = maxHealth;
            muertesTotal++;
            if(muertesTotal == 1)
            {
                lifes[2].SetActive(false);
            }
            else if(muertesTotal == 2)
            {
                lifes[1].SetActive(false);
            }
            else if(muertesTotal >= 3)
            {
                mainTheme.Stop();
                FindObjectOfType<AudioManager>().Play("GameOver");
                lifes[0].SetActive(false);
                Invoke("ActivePane", 0.5f);
            }
            

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
        FindObjectOfType<OpenInventory>().CloseInventory();
        FindObjectOfType<ActiveShop>().DisableShop();
        FindObjectOfType<PauseMenu>().Resume();
        Cursor.lockState = CursorLockMode.None;
        panelDeath.SetActive(true);
        Time.timeScale = 0f;
    }

}
