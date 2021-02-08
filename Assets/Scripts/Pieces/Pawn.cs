using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public Pawn(int side, GridNode[,] gridNode) : base(side)
    {
        this.name = "Pawn";
        this.cost = 1;
        SetupMoves(gridNode);   
    }

    public void SetupMoves(GridNode[,] gridNode)
    {
        moveSet = new Move[3];

        List<Vector2Int> pointList1 = pc.LineMoveCreator("00000001", side);
        moveSet[0] = new Move(new PureMove(gridNode), pointList1);
        List<Vector2Int> pointList2 = pc.PointMoveCreator(new List<(int, int)> { (0, 2) }, side);
        moveSet[1] = new Move(new FastMove(gridNode), pointList2);
        List<Vector2Int> pointList3 = pc.LineMoveCreator("10000010", side);
        moveSet[2] = new Move(new PureAtttack(gridNode), pointList3);
    }
}
