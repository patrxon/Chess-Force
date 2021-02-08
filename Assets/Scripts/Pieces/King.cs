using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    public King(int side, GridNode[,] gridNode) : base(side)
    {
        this.name = "King";
        this.cost = 20;
        SetupMoves(gridNode);
    }

    public void SetupMoves(GridNode[,] gridNode)
    {
        moveSet = new Move[1];

        List<Vector2Int> pointList1 = pc.LineMoveCreator("11111111", side);
        moveSet[0] = new Move(new AttackMove(gridNode), pointList1);
    }
}
