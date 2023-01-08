using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMapAppear : MonoBehaviour
{
    public GameObject light;
    // Start is called before the first frame update
    void Start()
    {
        light.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            light.SetActive(true);
        }
    }
}
