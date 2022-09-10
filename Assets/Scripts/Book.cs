using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
	public GameObject[] frases;
    public int i;

    private void Start()
    {
        i = 0;
        frases[0].SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Display();
        }
    }

    public void Previus()
    {
        frases[i].SetActive(false);
        i--;
        if (i < 0)
        {
            i = 0;
        }
        if (i < frases.Length)
        {
            frases[i].SetActive(true);

        }
        else
        {
            for (int a = 0; a < frases.Length; a++)
            {
                frases[a].SetActive(false);

            }
            frases[0].SetActive(true);
            i = 0;
        }
    }


    public void Display()
    {

        frases[i].SetActive(false);
        i++;
        if (i < frases.Length)
        {
            frases[i].SetActive(true);

        }
        else
        {
            for (int a = 0; a < frases.Length; a++)
            {
                frases[a].SetActive(false);

            }
            frases[0].SetActive(true);
            i = 0;
        }
    }
}
