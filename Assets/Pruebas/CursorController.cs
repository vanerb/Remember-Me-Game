using UnityEngine;
using UnityEngine.EventSystems;
public class CursorController : MonoBehaviour
{
    public float speed = 5f;

    private bool isClicking = false;

    void Update()
    {
        float x = Input.GetAxis("HorizontalJoystick") * speed * Time.deltaTime;
        float y = Input.GetAxis("VerticalJoystick") * speed * Time.deltaTime;
        transform.Translate(x, y, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            isClicking = true;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);
            if (hit.collider != null)
            {
                ExecuteEvents.Execute(hit.collider.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                ExecuteEvents.Execute(hit.collider.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler);
            }
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            isClicking = false;
        }
    }
}

