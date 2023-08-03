using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundProximity : MonoBehaviour
{
    public GameObject soundEmitter; // El objeto que emite el sonido
    public float activationDistance = 5f; // La distancia a la que el sonido se activará

    private AudioSource audioSource;
    public GameObject player;

    private void Start()
    {
        audioSource = soundEmitter.GetComponent<AudioSource>();
        audioSource.Stop(); // Detener el sonido al inicio
    }

    private void Update()
    {
        // Calcular la distancia entre el objeto que detecta y el objeto que emite el sonido
        float distance = Vector3.Distance(player.transform.position, transform.position);

        // Dibujar una línea de depuración para visualizar el rango de proximidad
        Debug.DrawLine(player.transform.position, transform.position, Color.yellow);

        // Si la distancia es menor o igual a la distancia de activación, reproducir el sonido
        if (distance <= activationDistance)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop(); // Si el objeto sale del rango, detener el sonido
        }
    }
}
