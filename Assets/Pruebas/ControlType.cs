using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlType : MonoBehaviour
{

    public static bool isMouseAndKeyboard;
    public static bool isGamepad;
    void Update()
    {
        float keyboardInput = GetKeyboardInput();
        float gamepadInput = GetGamepadInput();
        float mouseInput = GetMouseInput();



        // Si la entrada del teclado/rat�n es mayor que la entrada del gamepad, se utiliza el teclado/rat�n
        if (keyboardInput > gamepadInput || mouseInput>gamepadInput)
        {
            // L�gica para la entrada del teclado/rat�n
            Debug.Log("TECLADO Y RATON");
            isMouseAndKeyboard = true;
            isGamepad = false;
        }
        else // De lo contrario, se utiliza el gamepad
        {
            // L�gica para la entrada del gamepad
            Debug.Log("MANDO");
            isMouseAndKeyboard = false;
            isGamepad = true;
        }
    }

    float GetMouseInput()
    {
        float horizontalInput = Input.GetAxis("Mouse X");
        float verticalInput = Input.GetAxis("Mouse Y");
        return Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput);
    }

    float GetKeyboardInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        return Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput);
    }

    float GetGamepadInput()
    {
        float horizontalInput = Input.GetAxis("HorizontalJoystick");
        float verticalInput = Input.GetAxis("VerticalJoystick");

        return Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput);
    }


}
