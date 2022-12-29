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
        if (SkillTree.skillTree.skillLevels[6] >= 1 && SkillTree.skillTree.skillLevels[6] <= SkillTree.skillTree.skillCaps[6])
        {


            switch (SkillTree.skillTree.skillLevels[6])
            {
                case 0:
                    maxHealth = 105;
                    healthBar.SetMaxHealth(maxHealth);
                    healthBar.SetHealth(currentHealth);
                    break;
                case 1:
                    maxHealth = 110;
                    healthBar.SetMaxHealth(maxHealth);
                    healthBar.SetHealth(currentHealth);
                    break;

                case 2:
                    maxHealth = 115;
                    healthBar.SetMaxHealth(maxHealth);
                    healthBar.SetHealth(currentHealth);
                    break;

                case 3:
                    maxHealth = 120;
                    healthBar.SetMaxHealth(maxHealth);
                    healthBar.SetHealth(currentHealth);
                    break;

                case 4:
                    maxHealth = 125;
                    healthBar.SetMaxHealth(maxHealth);
                    healthBar.SetHealth(currentHealth);
                    break;

                case 5:
                    maxHealth = 130;
                    healthBar.SetMaxHealth(maxHealth);
                    healthBar.SetHealth(currentHealth);
                    break;

                case 6:
                    maxHealth = 135;
                    healthBar.SetMaxHealth(maxHealth);
                    healthBar.SetHealth(currentHealth);
                    break;

                case 7:
                    maxHealth = 140;
                    healthBar.SetMaxHealth(maxHealth);
                    healthBar.SetHealth(currentHealth);
                    break;

                case 8:
                    maxHealth = 145;
                    healthBar.SetMaxHealth(maxHealth);
                    healthBar.SetHealth(currentHealth);
                    break;

                case 9:
                    maxHealth = 150;
                    healthBar.SetMaxHealth(maxHealth);
                    healthBar.SetHealth(currentHealth);

                    break;

            }
        }

        


        if (currentHealth >= maxHealth)
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
                healthBar.SetHealth(currentHealth);
                lifes[2].SetActive(false);
            }
            else if(muertesTotal == 2)
            {
                healthBar.SetHealth(currentHealth);
                lifes[1].SetActive(false);
            }
            else if(muertesTotal == 3)
            {
                healthBar.SetHealth(currentHealth);
                lifes[0].SetActive(false);
            }
            else if(muertesTotal > 3)
            {
                //healthBar.SetHealth(0);
                mainTheme.Stop();
                FindObjectOfType<AudioManager>().Play("GameOver");
                //lifes[0].SetActive(false);
                Invoke("ActivePane", 0.5f);
                Debug.Log("MUERTO");
                isDeath = true;
            }
            

            
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
