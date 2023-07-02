using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdiomaSelect : MonoBehaviour
{
    public Dropdown languageDropdown;
    private string selectedLanguage;
    private const string LanguageKey = "SelectedLanguage";

    private void Start()
    {
        // Inicializar el desplegable con las opciones de idioma
        languageDropdown.AddOptions(new List<string> { "Español", "Inglés"});

        // Obtener el idioma guardado si existe
        if (PlayerPrefs.HasKey(LanguageKey))
        {
            selectedLanguage = PlayerPrefs.GetString(LanguageKey);
            int index = languageDropdown.options.FindIndex(option => option.text == selectedLanguage);
            languageDropdown.value = index;
        }
    }

    public void OnLanguageSelected(int index)
    {
        // Obtener el idioma seleccionado
        selectedLanguage = languageDropdown.options[index].text;

        // Guardar el idioma seleccionado en PlayerPrefs
        PlayerPrefs.SetString(LanguageKey, selectedLanguage);

        Debug.Log(PlayerPrefs.GetString("SelectedLanguage"));
    }
}
