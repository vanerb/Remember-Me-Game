using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button[] menuItems;
    public float selectDelay = 0.5f;

    private int selectedItemIndex = -1;
    private float lastSelectTime;

    void Start()
    {
        // Inicializar la selección del menú
        SelectMenuItem(0);
    }

    void Update()
    {
        if (ControlType.isGamepad && ControlType.isMouseAndKeyboard == false)
        {
            // Obtener el movimiento del joystick vertical
            float verticalInput = Input.GetAxisRaw("VerticalJoystick");

            // Verificar si se ha movido el joystick
            if (verticalInput != 0)
            {
                // Actualizar el tiempo de selección
                float currentTime = Time.time;
                float timeSinceLastSelect = currentTime - lastSelectTime;

                // Verificar si ha pasado suficiente tiempo desde la última selección
                if (timeSinceLastSelect >= selectDelay)
                {
                    // Seleccionar el elemento del menú correspondiente
                    if (verticalInput > 0 && selectedItemIndex > 0)
                    {
                        SelectMenuItem(selectedItemIndex - 1);
                    }
                    else if (verticalInput < 0 && selectedItemIndex < menuItems.Length - 1)
                    {
                        SelectMenuItem(selectedItemIndex + 1);
                    }

                    // Actualizar el tiempo de la última selección
                    lastSelectTime = currentTime;
                }
            }

            // Verificar si se ha presionado el botón A (o Enter)
            if (Input.GetButtonDown("Submit"))
            {
                // Ejecutar la acción del elemento seleccionado
                ExecuteSelectedMenuItem();
            }
        }
        
       
    }

    void SelectMenuItem(int index)
    {
        // Deseleccionar todos los elementos del menú
        DeselectMenuItems();

        // Seleccionar el elemento del menú indicado por el índice
        selectedItemIndex = index;
        Button selectedItem = menuItems[selectedItemIndex];
        selectedItem.Select();
        
    }

    void DeselectMenuItems()
    {
        // Deseleccionar todos los elementos del menú
        foreach (Button menuItem in menuItems)
        {
            menuItem.OnDeselect(null);
        }

        // Actualizar el índice del elemento seleccionado
        selectedItemIndex = -1;
    }

    void ExecuteSelectedMenuItem()
    {
        // Verificar si hay un elemento seleccionado
        if (selectedItemIndex >= 0 && selectedItemIndex < menuItems.Length)
        {
            // Ejecutar la acción del elemento seleccionado
            Debug.Log("Ejecutando acción para elemento seleccionado: " + menuItems[selectedItemIndex].name);
        }
    }
}


