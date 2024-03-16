using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Vector3 mousePos;
    public Vector3 mousePosWorld { get { return Camera.main.ScreenToWorldPoint(mousePos); } }  
    public Vector3 mousePosTileCenter { get { return GetTileCenterFromMouse(mousePosWorld); } }

    public Action keyAction = null;

    // Update is called once per frame
    public void OnUpdate()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 10.0F;

        if (Input.anyKey == false) return;

        keyAction?.Invoke();
    }

    private Vector3 GetTileCenterFromMouse(Vector3 _mousePos)
    {
        _mousePos.x = Mathf.Round(_mousePos.x);
        _mousePos.y = Mathf.Round(_mousePos.y);
        return _mousePos;
    }
}
