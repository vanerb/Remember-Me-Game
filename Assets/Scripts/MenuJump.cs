using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class MenuJump : MonoBehaviour
{
	// Use this for initialization
	/*public int index;
	[SerializeField] bool keyDown;
	[SerializeField] int maxIndex;
	
	public Button[] button;

	public GameObject[] buttons;

	string[] joysticks;
	int joysticksCount = 0;
	int iskey = 0;

	void Start()
	{
		
		
	}

	

	// Update is called once per frame
	void Update()
	{
		joysticks = Input.GetJoystickNames();
		if (joysticks.Length != joysticksCount)
		{
			joysticksCount = joysticks.Length;
			Debug.LogError($"Joysticks updated, Count {joysticksCount}");
		}
		foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
		{
			if (Input.GetKeyDown(key))
			{
				Debug.LogError($"Key {key.ToString()} Pressed");
				iskey = 0;
				

			}
            else
            {
				
				iskey = 1;
            }
		}
		if(iskey == 1)
        {
			if (Input.GetAxis("AXIS_1") != 0)
			{
				setButtonsActive(true, index);
				
				if (!keyDown)
				{
					if (Input.GetAxis("AXIS_1") < 0)
					{
						if (index < maxIndex)
						{
							index++;
						}
						else
						{
							index = 0;
						}
					}
					else if (Input.GetAxis("AXIS_1") > 0)
					{
						if (index > 0)
						{
							index--;
						}
						else
						{
							index = maxIndex;
						}
					}
					keyDown = true;
				}
			}
			else
			{
				keyDown = false;
			}
		}

		
	}

	private void setButtonsActive(bool set, int index)
	{
		buttons[index].SetActive(set);
		if (set)
			EventSystem.current.SetSelectedGameObject(buttons[index].GetComponentInChildren<Button>().gameObject, null);
		else
			EventSystem.current.SetSelectedGameObject(null);
	}*/
}
