using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fort : Piece
{
    public Fort(int side, GridNode[][] gridNode) : base(side)
    {
        this.Name = "Fort";
        this.Cost = 1;
        SetupMoves(gridNode);
    }

    public void SetupMoves(GridNode[][] gridNode)
    {
        MoveSet = new Move[2];

        List<Vector2Int> pointList1 = PieceContainer.LineMoveCreator("00010001", Side);
        MoveSet[0] = new Move(new AttackMove(gridNode), pointList1);
        List<Vector2Int> pointList2 = PieceContainer.LineMoveCreator("01000100", Side);
        MoveSet[1] = new Move(new PureAtttack(gridNode), pointList2);
    }
}
