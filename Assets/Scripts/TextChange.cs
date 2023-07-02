using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{

    public Text textElement;
    [TextArea(3, 6)]
    public string textoEspanol;
    [TextArea(3, 6)]
    public string textoEnglish;

    public void Start()
    {
        if (PlayerPrefs.GetString("SelectedLanguage") == "Inglés")
        {
            textElement.text = textoEnglish;

        }
        else
        {
            textElement.text = textoEspanol;

        }
    }

    private void Update()
    {

        if (PlayerPrefs.GetString("SelectedLanguage") == "Inglés")
        {
            textElement.text = textoEnglish;

        }
        else
        {
            textElement.text = textoEspanol;

        }
    }

    public void ChangeText(string newText)
    {
        textElement.text = newText;
    }
}
