using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CeldJump : MonoBehaviour
{
	// Use this for initialization
	public int index;
	[SerializeField] bool keyDown;
	[SerializeField] int maxIndex;
	//public AudioSource audioSource;
	public Image[] celds;

	void Start()
	{
		//audioSource = GetComponent<AudioSource>();
		celds[index].color = Color.grey;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetAxis("Vertical") != 0)
		{
			celds[index].color = Color.white;
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
			celds[index].color = Color.grey;
			keyDown = false;
		}
	}
}
