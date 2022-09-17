using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
	[SerializeField] OptionJump menuButtonController;
	//[SerializeField] Animator animator;
	//[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;
	//[SerializeField] Image buttonSprite;
	//[SerializeField] Button button;
	//[SerializeField] TMP_Dropdown dropdown;
	//[SerializeField] Dropdown dropdownN;

	private void Start()
	{

		//dropdownN.Select();
		//dropdown.Select();

	}
	// Update is called once per frame
	void Update()
	{
		if (menuButtonController.index == thisIndex)
		{
			//animator.SetBool("selected", true);
			if (Input.GetAxis("Submit") == 1)
			{

				//buttonSprite.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
				//animator.SetBool("pressed", true);
			}
			//else if (animator.GetBool("pressed"))
			//{
			//animator.SetBool("pressed", false);
			//	animatorFunctions.disableOnce = true;
			//}
		}
		else
		{
			//animator.SetBool("selected", false);
		}
	}
}
