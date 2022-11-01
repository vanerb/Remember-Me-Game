using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeldFunction : MonoBehaviour
{
	[SerializeField] CeldJump menuButtonController;
	[SerializeField] int thisIndex;
	public Inventory inventory;
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
				Debug.Log("Boton: " + menuButtonController.index);
				if(inventory.slots[i].GetComponentInChildren<TakeLife>() == true)
                {
					inventory.slots[i].GetComponentInChildren<TakeLife>().Function();
                }

				if (inventory.slots[i].GetComponentInChildren<PowerPotion>() == true)
				{
					Debug.Log("ES UNA POCION DE PODER");
					inventory.slots[i].GetComponentInChildren<PowerPotion>().Function();
				}

				if (inventory.slots[i].GetComponentInChildren<PotionInvisibility>() == true)
				{
					Debug.Log("ES UNA POCION DE PODER");
					inventory.slots[i].GetComponentInChildren<PotionInvisibility>().Function();
				}

				if (inventory.slots[i].GetComponentInChildren<PotionPoison>() == true)
				{
					Debug.Log("ES UNA POCION DE PODER");
					inventory.slots[i].GetComponentInChildren<PotionPoison>().Function();
				}

				//buttonSprite.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
				//animator.SetBool("pressed", true);
			}

            if (Input.GetKeyDown(KeyCode.Joystick1Button2)|| Input.GetKeyDown(KeyCode.T))
            {
				Debug.Log("Boton: " + menuButtonController.index);
				if (inventory.slots[i].GetComponentInChildren<TakeLife>() == true)
				{
					inventory.slots[i].GetComponentInChildren<Slot>().DropItem();
				}

				if (inventory.slots[i].GetComponentInChildren<PowerPotion>() == true)
				{
					Debug.Log("ES UNA POCION DE PODER");
					inventory.slots[i].GetComponentInChildren<Slot>().DropItem();
				}

				if (inventory.slots[i].GetComponentInChildren<PotionInvisibility>() == true)
				{
					inventory.slots[i].GetComponentInChildren<Slot>().DropItem();
				}

				if (inventory.slots[i].GetComponentInChildren<PotionPoison>() == true)
				{
					inventory.slots[i].GetComponentInChildren<Slot>().DropItem();
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
