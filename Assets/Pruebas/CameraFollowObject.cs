using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    public Transform[] focusPoints; // Array de objetos que representan los puntos de enfoque
    public float moveSpeed = 5f; // Velocidad de movimiento de la cámara
    public float waitTime = 1f; // Tiempo de espera después de enfocar un punto

    private Transform currentFocusPoint; // Objeto actual que la cámara está enfocando
    private bool isFocusing = false; // Indica si la cámara está enfocando un punto

    private Vector3 originalPosition; // Posición original de la cámara
    private Quaternion originalRotation; // Rotación original de la cámara
    public GameObject cameraObject;
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        if (isFocusing)
        {
            // Mueve la cámara hacia el punto de enfoque actual
            transform.position = Vector3.MoveTowards(transform.position, currentFocusPoint.position, moveSpeed * Time.deltaTime);

            // Si la cámara ha llegado al punto de enfoque actual, espera un tiempo antes de volver a la posición original
            if (transform.position == currentFocusPoint.position)
            {
                StartCoroutine(WaitBeforeReturning());
                //cameraObject.SetActive(false);

            }
        }
    }

    IEnumerator WaitBeforeReturning()
    {
        yield return new WaitForSeconds(waitTime);

        // Vuelve la cámara a su posición original
        isFocusing = false;
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        cameraObject.SetActive(false);
    }

    public void FocusOff()
    {
        isFocusing = false;
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        cameraObject.SetActive(false);

    }

    public void FocusOn(int focusIndex)
    {
        cameraObject.SetActive(true);
        if (focusIndex < 0 || focusIndex >= focusPoints.Length) return;

        // Guarda el objeto actual que la cámara está enfocando
        currentFocusPoint = focusPoints[focusIndex];

        // Indica que la cámara está enfocando un punto
        isFocusing = true;
    }

}
