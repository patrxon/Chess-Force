using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    public Rook(int side, GridNode[,] gridNode) : base(side)
    {
        this.name = "Rook";
        this.cost = 8;
        SetupMoves(gridNode);
    }

    public void SetupMoves(GridNode[,] gridNode)
    {
        moveSet = new Move[1];

        List<Vector2Int> pointList = pc.LineMoveCreator("07070707", side);
        moveSet[0] = new Move(new AttackMove(gridNode), pointList);
    }
}
