using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private Camera _mainCamera;
    private Vector3 _lastMouthPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // CardMove();
    }

    private void OnMouseDrag()
    {
        // TODO: 此时使当前刚体变为触发器
        CardMove();
    }

    private void OnMouseUp() =>  _lastMouthPosition = Vector3.zero;

    private void CardMove()
    {
        if (!Input.GetMouseButton(0)) return;
        Vector3 currentMouthPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        if (_lastMouthPosition == Vector3.zero) _lastMouthPosition = currentMouthPosition;
        Vector3 changePosition = currentMouthPosition - _lastMouthPosition;
        Debug.Log("加速度x：" + (currentMouthPosition.x - _lastMouthPosition.x)/Time.deltaTime +
                  "\n加速度y：" + (currentMouthPosition.y - _lastMouthPosition.y)/Time.deltaTime);

        _lastMouthPosition = currentMouthPosition;
        changePosition.z = 0f;
        transform.Translate(changePosition);
    }
}
