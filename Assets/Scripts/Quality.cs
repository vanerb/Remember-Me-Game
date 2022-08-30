using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quality : MonoBehaviour
{
    public Dropdown dropdown;
    public int quality;
    // Start is called before the first frame update
    void Start()
    {
        quality = PlayerPrefs.GetInt("Calidad", 5);
        dropdown.value = quality;
        AdjustQuality();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AdjustQuality()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("Calidad", dropdown.value);
        quality = dropdown.value;
    }
}
