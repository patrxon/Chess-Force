using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    public Rook(int side, GridNode[][] gridNode) : base(side)
    {
        this.Name = "Rook";
        this.Cost = 8;
        SetupMoves(gridNode);
    }

    public void SetupMoves(GridNode[][] gridNode)
    {
        MoveSet = new Move[1];

        List<Vector2Int> pointList = PieceContainer.LineMoveCreator("07070707", Side);
        MoveSet[0] = new Move(new AttackMove(gridNode), pointList);
    }
}
