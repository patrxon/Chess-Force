using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    public Queen(int side, GridNode[,] gridNode) : base(side)
    {
        this.name = "Queen";
        this.cost = 10;
        SetupMoves(gridNode);
    }

    public void SetupMoves(GridNode[,] gridNode)
    {
        moveSet = new Move[1];

        List<Vector2Int> pointList = pc.LineMoveCreator("77777777", side);
        moveSet[0] = new Move(new AttackMove(gridNode), pointList);
    }
}
