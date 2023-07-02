
using UnityEngine;
using UnityEngine.UI;
using static SkillTree;

public class Skill : MonoBehaviour
{
    public int id;
    public Text txtTitle;
    public Text txtDexription;
    public int[] connectedUpgrades;
    //public AudioSource audiobuy;

    public void UpdateUI()
    {

        if (PlayerPrefs.GetString("SelectedLanguage") == "Inglés")
        {
            txtTitle.text = $"{skillTree.skillLevels[id]}/{skillTree.skillCaps[id]}\n{skillTree.skillNamesEn[id]}";

            txtDexription.text = $"{skillTree.skilDescriptionEn[id]}\ncost:{skillTree.skillPoint}/1 SP";
        }
        else
        {
            txtTitle.text = $"{skillTree.skillLevels[id]}/{skillTree.skillCaps[id]}\n{skillTree.skillNames[id]}";

            txtDexription.text = $"{skillTree.skilDescription[id]}\ncost:{skillTree.skillPoint}/1 SP";
        }

        


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
        //audiobuy.Play();
        skillTree.skillPoint -= 1;
        skillTree.skillLevels[id]++;
        skillTree.UpdateAllSkillUi();





    }
}
