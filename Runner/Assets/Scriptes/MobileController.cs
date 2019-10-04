using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MobileController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image joystickBG;
    private Image joystick;
    private Vector2 direction;

    private void Start()
    {
        joystickBG = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBG.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / joystickBG.rectTransform.sizeDelta.x);
            pos.y = (pos.y / joystickBG.rectTransform.sizeDelta.x);
        }

        direction = new Vector2(pos.x * 2 - 1, pos.y * 2 - 1);
        direction = (direction.magnitude > 1.0f) ? direction.normalized : direction;

        joystick.rectTransform.anchoredPosition = new Vector2(direction.x * (joystick.rectTransform.sizeDelta.x), direction.y * (joystick.rectTransform.sizeDelta.y));
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        direction = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public float Horizontal()
    {
        if (direction.x != 0)
            return direction.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (direction.y != 0)
            return direction.y;
        else
            return Input.GetAxis("Vertical");
    }
}
