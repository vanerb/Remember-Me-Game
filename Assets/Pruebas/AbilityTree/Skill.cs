
using UnityEngine;
using UnityEngine.UI;
using static SkillTree;

public class Skill : MonoBehaviour
{
    public int id;
    public Text txtTitle;
    public Text txtDexription;
    public int[] connectedUpgrades;

    public void UpdateUI()
    {
        txtTitle.text = $"{skillTree.skillLevels[id]}/{skillTree.skillCaps[id]}\n{skillTree.skillNames[id]}";

        txtDexription.text = $"{skillTree.skilDescription[id]}\ncost:{skillTree.skillPoint}/1 SP";


        GetComponent<Image>().color = skillTree.skillLevels[id] >= skillTree.skillCaps[id] ? Color.yellow : skillTree.skillPoint > 0 ? Color.green : Color.white;

        foreach (var connectedSkil in connectedUpgrades)
        {
            skillTree.skillsList[connectedSkil].gameObject.SetActive(skillTree.skillLevels[id] > 0);
            skillTree.connectionList[connectedSkil].SetActive(skillTree.skillLevels[id] > 0);

        }
    }

    public void Buy()
    {

        if (skillTree.skillPoint < 1 || skillTree.skillLevels[id] >= skillTree.skillCaps[id])
        {

            return;
        }
        
        skillTree.skillPoint -= 1;
        skillTree.skillLevels[id]++;
        skillTree.UpdateAllSkillUi();





    }
}
