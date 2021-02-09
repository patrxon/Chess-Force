using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    public King(int side, GridNode[][] gridNode) : base(side)
    {
        this.Name = "King";
        this.Cost = 20;
        SetupMoves(gridNode);
    }

    public void SetupMoves(GridNode[][] gridNode)
    {
        MoveSet = new Move[1];

        List<Vector2Int> pointList1 = PieceContainer.LineMoveCreator("11111111", Side);
        MoveSet[0] = new Move(new AttackMove(gridNode), pointList1);
    }
}
