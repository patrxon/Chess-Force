using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public IMoveType MoveType { get; }
    public List<Vector2Int> PointList { get; }

    public Move(IMoveType moveType, List<Vector2Int> pointList)
    {
        PointList = pointList;
        MoveType = moveType;
    }
}
