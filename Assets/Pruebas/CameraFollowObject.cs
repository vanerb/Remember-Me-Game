using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    public Transform[] focusPoints;
    public float moveSpeed = 6f;
    public float waitTime = 1f;

    private Transform currentFocusPoint;
    private Transform lastFocusPoint;
    public bool isFocusing = false;

    private Quaternion originalRotation;
    public GameObject cameraObject;

    public static bool isActiveObject;


    void Start()
    {
        // Asigna la posición actual del jugador como la posición inicial de la cámara
        transform.position = Camera.main.transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        if (isFocusing)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentFocusPoint.position, moveSpeed * Time.deltaTime);

            if (transform.position == currentFocusPoint.position)
            {
                StartCoroutine(WaitBeforeReturning());
            }
        }
    }

    IEnumerator WaitBeforeReturning()
    {
        yield return new WaitForSeconds(waitTime);

        // Actualiza el último punto de enfoque
        lastFocusPoint = currentFocusPoint;

        isFocusing = false;
        // Vuelve la cámara a la posición actual del jugador en lugar de la posición original de la cámara
        transform.position = Camera.main.transform.position;
        transform.rotation = originalRotation;
        cameraObject.SetActive(false);
        isActiveObject = false;
    }

    public void FocusOn(int focusIndex)
    {
        cameraObject.SetActive(true);
        if (isFocusing)
        {
            if (lastFocusPoint != null)
            {
                currentFocusPoint = lastFocusPoint;
                return;
            }
        }

        if (focusIndex < 0 || focusIndex >= focusPoints.Length) return;

        currentFocusPoint = focusPoints[focusIndex];

        isFocusing = true;
        isActiveObject = true;
    }

}
