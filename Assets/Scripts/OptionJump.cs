using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionJump : MonoBehaviour
{
	// Use this for initialization
	public int index;
	[SerializeField] bool keyDown;
	[SerializeField] int maxIndex;
	//public AudioSource audioSource;
	
	public GameObject[] elements;
	
	void Start()
	{
		//audioSource = GetComponent<AudioSource>();
		//togle[index].Select();
		//slider[index].Select();
		//dropdowns[index].Select();
		//button[index].Select();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetAxis("Vertical") != 0)
		{
			//togle[index].Select();
			//slider[index].Select();
			//dropdowns[index].Select();
			//button[index].Select();
			elements[index].GetComponent<Selectable>().Select();
		
			if (!keyDown)
			{
				if (Input.GetAxis("Vertical") < 0)
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
				else if (Input.GetAxis("Vertical") > 0)
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
