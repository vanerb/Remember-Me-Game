using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveMapWithMouse : MonoBehaviour
{
    Vector3 origin;
    Vector3 Difference;
    Vector3 ResetCamera;


    bool drag = false;

    public Camera camera;

    private void Start()
    {
        ResetCamera = camera.transform.position;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Difference = (camera.ScreenToWorldPoint(Input.mousePosition)) - camera.transform.position;
            if(drag == false)
            {
                drag = true;
                origin = camera.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }

        if (drag)
        {
            camera.transform.position = origin - Difference;
        }

        if (Input.GetMouseButton(1))
        {
            camera.transform.position = ResetCamera;
        }
    }
}
