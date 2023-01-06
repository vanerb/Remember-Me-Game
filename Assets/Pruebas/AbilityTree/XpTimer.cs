using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpTimer : MonoBehaviour
{
    public float time;
    public float timeforxp;
    public GameObject potionxp;
    public Transform player;
    public GameObject panelLevelup;
    public bool isPassed = false;
    public int totalpoints;
    // Start is called before the first frame update
    void Start()
    {
        time = 180;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        panelLevelup.SetActive(false);
        isPassed = false;
        totalpoints = SkillTree.skillTree.skillPoint;
    }

    // Update is called once per frame
    void Update()
    {
        totalpoints = SkillTree.skillTree.pointstotal;



        if (totalpoints<32 && isPassed == false)
        {
            time -= Time.deltaTime;


            if (totalpoints <= 3)
            {
                timeforxp = 180;
            }
            else if(totalpoints <= 10)
            {
                timeforxp = 240;
            }
            else if (totalpoints <= 15)
            {
                timeforxp = 300;
            }
            else if (totalpoints <= 20)
            {
                timeforxp = 360;
            }
            else if (totalpoints <= 31)
            {
                timeforxp = 420;
            }
            if (time <= 0)
            {
                panelLevelup.SetActive(true);
                StartCoroutine(timeToPanel(3f));
                Vector2 playerPos = new Vector2(player.position.x, player.position.y);
                Instantiate(potionxp, playerPos, Quaternion.identity);
                time = timeforxp;
            }
        }

        if (totalpoints >= 31)
        {
            isPassed = true;
            SkillTree.skillTree.skillPoint = 31;
            SkillTree.skillTree.UpdateAllSkillUi();
        }
       
    }

    IEnumerator timeToPanel(float time)
    {

        yield return new WaitForSeconds(time);
        panelLevelup.SetActive(false);
    }
}
