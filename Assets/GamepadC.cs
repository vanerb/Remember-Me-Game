using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class GamepadC : StandaloneInputModule
{

    private Vector2 cursorPosition;

    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;


    private void Start()
    {
        // optional place it in the center on start
        cursorPosition = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Vector3 tmpScreenPos = Camera.main.WorldToScreenPoint(cursorPosition);


    }


    private void Update()
    {

        if (Hinput.anyGamepad.A.justPressed)
        {
            ClickAt(cursorPosition.x, cursorPosition.y);
        }

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


    private void OnGUI()
    {
        if (Hinput.anyGamepad.isConnected == true && PauseMenu.isActive || OpenInventory.isActive == false || OpenBook.isBookEnabled == false || OpenStorageBook.isActive == false || ActiveShop.isShopEnabled || LifePlayer.isDeath || OpenAbilityTree.isEnabled == false)
        {

            float h = horizontalSpeed * Input.GetAxis("AXIS_0") * Time.unscaledDeltaTime;
            float v = -verticalSpeed * Input.GetAxis("AXIS_1") * Time.unscaledDeltaTime;

            // add the changes to the actual cursor position
            cursorPosition.x += h;
            cursorPosition.y += v;

            if (Hinput.anyGamepad.isConnected)
            {
                CursorControl.SetGlobalCursorPos(new Vector2(cursorPosition.x, cursorPosition.y));

            }


        }
    }


}
