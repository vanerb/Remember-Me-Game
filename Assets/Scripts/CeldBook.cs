using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CeldBook : MonoBehaviour
{
	[SerializeField] CeldJump menuButtonController;
	[SerializeField] int thisIndex;
	public BookStorage inventory;
	public int i;
	public GameObject panel;
	
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
				if (inventory.slots[i].GetComponentInChildren<ActiveSheet>() == true)
				{
					OpenStorageBook.isActive = true;
					panel.SetActive(false);
					inventory.slots[i].GetComponentInChildren<ActiveSheet>().Active();
				}
				



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
