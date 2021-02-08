using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    public Bishop(int side, GridNode[,] gridNode) : base(side)
    {
        this.name = "Bishop";
        this.cost = 6;
        SetupMoves(gridNode);
    }

    public void SetupMoves(GridNode[,] gridNode)
    {
        moveSet = new Move[1];

        List<Vector2Int> pointList = pc.LineMoveCreator("70707070", side);
        moveSet[0] = new Move(new AttackMove(gridNode), pointList);
    }
}
