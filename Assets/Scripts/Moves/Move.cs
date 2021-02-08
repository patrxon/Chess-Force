using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public MoveType moveType { get; }
    public List<Vector2Int> pointList { get; }

    public Move(MoveType moveType ,List<Vector2Int> pointList)
    {
        this.pointList = pointList;
        this.moveType = moveType;
    }
}
