using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    public Knight(int side, GridNode[,] gridNode) : base(side)
    {
        this.name = "Knight";
        this.cost = 6;
        SetupMoves(gridNode);
    }

    public void SetupMoves(GridNode[,] gridNode)
    {
        moveSet = new Move[1];

        List<Vector2Int> pointList = pc.PointMoveCreator(new List<(int, int)> { (1, 2), (-1, 2), (2, 1), (2, -1), (-2, 1), (-2, -1), (1, -2), (-1, -2) }, side);
        moveSet[0] = new Move(new JumpAttackMove(gridNode), pointList);
    }
}
