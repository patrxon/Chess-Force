using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    public Bishop(int side, GridNode[][] gridNode) : base(side)
    {
        this.Name = "Bishop";
        this.Cost = 6;
        SetupMoves(gridNode);
    }

    public void SetupMoves(GridNode[][] gridNode)
    {
        MoveSet = new Move[1];

        List<Vector2Int> pointList = PieceContainer.LineMoveCreator("70707070", Side);
        MoveSet[0] = new Move(new AttackMove(gridNode), pointList);
    }
}
