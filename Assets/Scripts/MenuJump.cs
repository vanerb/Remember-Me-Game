using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuJump : MonoBehaviour
{
	// Use this for initialization
	public int index;
	[SerializeField] bool keyDown;
	[SerializeField] int maxIndex;
	//public AudioSource audioSource;
	public Button[] button;

	void Start()
	{
		//audioSource = GetComponent<AudioSource>();
		button[index].Select();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetAxis("Vertical") != 0)
		{
			button[index].Select();
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
