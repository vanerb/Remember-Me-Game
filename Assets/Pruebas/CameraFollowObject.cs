using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    public Transform[] focusPoints; // Array de objetos que representan los puntos de enfoque
    public float moveSpeed = 5f; // Velocidad de movimiento de la c�mara
    public float waitTime = 1f; // Tiempo de espera despu�s de enfocar un punto

    private Transform currentFocusPoint; // Objeto actual que la c�mara est� enfocando
    private bool isFocusing = false; // Indica si la c�mara est� enfocando un punto

    private Vector3 originalPosition; // Posici�n original de la c�mara
    private Quaternion originalRotation; // Rotaci�n original de la c�mara
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
            // Mueve la c�mara hacia el punto de enfoque actual
            transform.position = Vector3.MoveTowards(transform.position, currentFocusPoint.position, moveSpeed * Time.deltaTime);

            // Si la c�mara ha llegado al punto de enfoque actual, espera un tiempo antes de volver a la posici�n original
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

        // Vuelve la c�mara a su posici�n original
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

        // Guarda el objeto actual que la c�mara est� enfocando
        currentFocusPoint = focusPoints[focusIndex];

        // Indica que la c�mara est� enfocando un punto
        isFocusing = true;
    }

}
