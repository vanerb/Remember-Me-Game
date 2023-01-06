using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpPotion : MonoBehaviour
{
    public int randomXP;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            randomXP = Random.Range(1, 5);
            SkillTree.skillTree.skillPoint+=randomXP;
            SkillTree.skillTree.pointstotal += SkillTree.skillTree.skillPoint;
            SkillTree.skillTree.UpdateAllSkillUi();
            Destroy(this.gameObject);
        }
    }
}
