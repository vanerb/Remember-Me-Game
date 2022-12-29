using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class GamepadCursorLevel : StandaloneInputModule
{
    private Vector2 cursorPosition;
    public Texture2D cursorImage;

    private int cursorWidth = 32;
    private int cursorHeight = 32;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;


    private void Start()
    {
        
        
        if (Hinput.anyGamepad.isConnected == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
        }


        // optional place it in the center on start
        cursorPosition = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Vector3 tmpScreenPos = Camera.main.WorldToScreenPoint(cursorPosition);


    }

    public void ClickAt(float x, float y)
    {
        Input.simulateMouseWithTouches = true;
        var pointerData = GetTouchPointerEventData(new Touch()
        {
            position = new Vector2(x, y),
        }, out bool b, out bool bb);

        ProcessTouchPress(pointerData, true, true);
        ProcessTouchPress(pointerData, true, false);


    }

    




    private void Update()
    {
        if (Hinput.anyGamepad.A.justPressed)
        {
            Click();
        }


        if (Hinput.anyGamepad.isConnected == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
        }

       
    }

    public void Click()
    {
        
        ClickAt(cursorPosition.x, cursorPosition.y);
        
        
    }

    private void OnGUI()
    {
        if (Hinput.anyGamepad.isConnected == true && PauseMenu.isActive || OpenInventory.isActive == false || OpenBook.isBookEnabled == false || OpenStorageBook.isActive == false || ActiveShop.isShopEnabled || LifePlayer.isDeath || OpenAbilityTree.isEnabled == false)
        {
            
                float h = horizontalSpeed * Input.GetAxis("AXIS_0") * Time.unscaledDeltaTime;
                float v = verticalSpeed * Input.GetAxis("AXIS_1") * Time.unscaledDeltaTime;

                // add the changes to the actual cursor position
                cursorPosition.x += h;
                cursorPosition.y += v;


            if (Hinput.anyGamepad.isConnected)
            {
                GUI.DrawTexture(new Rect(cursorPosition.x, Screen.height - cursorPosition.y, cursorWidth, cursorHeight), cursorImage);

            }


        }



    }
}
