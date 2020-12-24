using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject player;
    public RectTransform touchArea;
    public Image out_pad;
    public Image in_pad;

    private Vector2 joystickVector;
    private Vector3 input = Vector3.zero;
    private float degree;

    public float speed = 5;
    public float rotatespeed = 5f;
    public float Horizontal { get { return input.x; } }
    public float Vertical { get { return input.y; } }
    public Vector3 angle { get { return new Vector3(0, 0, degree); } }
    public void OnDrag(PointerEventData eventData)
    {
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(touchArea, eventData.position, eventData.pressEventCamera, out Vector2 localPoint))
        {
            input.x = localPoint.x = (localPoint.x / touchArea.sizeDelta.x);
            input.y = localPoint.y = (localPoint.y / touchArea.sizeDelta.y);
            degree = GetDegree(Vector3.zero, input);

            joystickVector = new Vector2(localPoint.x * 2.6f, localPoint.y * 2);

            joystickVector = (joystickVector.magnitude > 0.35f) ? joystickVector.normalized * 0.35f : joystickVector;

            in_pad.rectTransform.anchoredPosition = new Vector2(joystickVector.x * (out_pad.rectTransform.sizeDelta.x), joystickVector.y * (out_pad.rectTransform.sizeDelta.y));
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        in_pad.rectTransform.anchoredPosition = Vector2.zero;
        input = Vector3.zero;
        degree = 0f;
    }
    float GetDegree(Vector3 from, Vector3 to)
    {
        return Mathf.Atan2(to.y - from.y, to.x - from.x) * 180 / Mathf.PI;
    }
}
