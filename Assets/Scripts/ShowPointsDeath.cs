using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPointsDeath : MonoBehaviour
{
    public Points points;
    public Text txtPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txtPoints.text = "Puntos Totales: " + points.points;
    }
}
