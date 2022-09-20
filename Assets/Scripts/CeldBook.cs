using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeldBook : MonoBehaviour
{
	[SerializeField] CeldJump menuButtonController;
	[SerializeField] int thisIndex;
	public BookStorage inventory;
	public int i;
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
			if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.E))
			{



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
