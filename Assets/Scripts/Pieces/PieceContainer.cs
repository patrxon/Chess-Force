using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceContainer
{

    private readonly List<Vector2Int> _dirList = new List<Vector2Int>
    { new Vector2Int(1, 1), new Vector2Int(1, 0), new Vector2Int(1, -1),
      new Vector2Int(0, -1) ,new Vector2Int(-1, -1), new Vector2Int(-1, 0),
      new Vector2Int(-1, 1), new Vector2Int(0, 1)};

    public List<Vector2Int> LineMoveCreator(string length, int side)
    {
        List<Vector2Int> pointList = new List<Vector2Int>();

        for (int dir = 0; dir < 8; dir++)
        {
            for (int j = 1; j <= length[dir] - '0'; j++)
            {
                pointList.Add(_dirList[dir] * new Vector2Int(1, side) * j);
            }
        }

        return pointList;
    }

    public List<Vector2Int> PointMoveCreator(List<(int, int)> points, int side)
    {
        List<Vector2Int> pointList = new List<Vector2Int>();

        foreach ((int x, int y) in points)
        {
            pointList.Add(new Vector2Int(x, y) * new Vector2Int(1, side));
        }

        return pointList;
    }
}
