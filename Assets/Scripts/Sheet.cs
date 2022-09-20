using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sheet
{
	public string title;

	[TextArea(3, 20)]
	public string[] content;
}
