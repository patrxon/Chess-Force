using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fort : Piece
{
    public Fort(int side, GridNode[,] gridNode) : base(side)
    {
        this.name = "Fort";
        this.cost = 1;
        SetupMoves(gridNode);
    }

    public void SetupMoves(GridNode[,] gridNode)
    {
        moveSet = new Move[2];

        List<Vector2Int> pointList1 = pc.LineMoveCreator("00010001", side);
        moveSet[0] = new Move(new AttackMove(gridNode), pointList1);
        List<Vector2Int> pointList2 = pc.LineMoveCreator("01000100", side);
        moveSet[1] = new Move(new PureAtttack(gridNode), pointList2);
    }
}
