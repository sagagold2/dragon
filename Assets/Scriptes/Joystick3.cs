﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Joystick3 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Image ImgBg;
    public Image ImgJoystick;

    private Vector3 _inputVector;



    public Vector3 InputVector
    {
        get
        {
            return _inputVector;
        }
    }

    public void OnPointerDown(PointerEventData e)
    {
        OnDrag(e);
    }

    public void OnDrag(PointerEventData e)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(ImgBg.rectTransform,
                                                                    e.position,
                                                                    e.pressEventCamera,
                                                                    out pos))
        {

            pos.x = (pos.x / ImgBg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / ImgBg.rectTransform.sizeDelta.y);

            _inputVector = new Vector3(pos.x * 2, 0, pos.y * 2); //처음 클릭시 조이스틱의 움직이는 방향설정(현재는 아무 방향으로 움직이지 않음
            _inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;

            ImgJoystick.rectTransform.anchoredPosition = new Vector3(_inputVector.x * (ImgBg.rectTransform.sizeDelta.x * .4f),
                                                                     _inputVector.z * (ImgBg.rectTransform.sizeDelta.y * .4f));




        }
    }

    public void OnPointerUp(PointerEventData e)
    {
        _inputVector = Vector3.zero;
        ImgJoystick.rectTransform.anchoredPosition = Vector3.zero;
    }


    public float Horizontal()
    {
        if (_inputVector.x != 0)
        {
            return _inputVector.x;
        }

        return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (_inputVector.z != 0)
        {
            return _inputVector.z;
        }

        return Input.GetAxis("Vertical");
    }

}
