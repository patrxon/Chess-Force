using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController
{
    private readonly int _gridWitdh = 8;
    private readonly int _gridHeight = 8;

    public bool IsMouseInGrid(Vector2 mousePos) => mousePos.x >= 0 && mousePos.x < _gridWitdh && mousePos.y >= 0 && mousePos.y < _gridHeight;

    private Vector3 GetMousePos()
    {
        Vector2 mousePos;
        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;

        return Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
    }

    public Vector2Int GetPosInGrid()
    {
        Vector3 PosInUnits = GetMousePos();

        return new Vector2Int((int)PosInUnits.x, (int)PosInUnits.y);
    }

    public Vector2 GetFloatPosInGrid()
    {
        Vector3 PosInUnits = GetMousePos();

        return new Vector2(PosInUnits.x, PosInUnits.y);
    }
}
