using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public Pawn(int side, GridNode[][] gridNode) : base(side)
    {
        this.Name = "Pawn";
        this.Cost = 1;
        SetupMoves(gridNode);   
    }

    public void SetupMoves(GridNode[][] gridNode)
    {
        MoveSet = new Move[3];

        List<Vector2Int> pointList1 = PieceContainer.LineMoveCreator("00000001", Side);
        MoveSet[0] = new Move(new PureMove(gridNode), pointList1);
        List<Vector2Int> pointList2 = PieceContainer.PointMoveCreator(new List<(int, int)> { (0, 2) }, Side);
        MoveSet[1] = new Move(new FastMove(gridNode), pointList2);
        List<Vector2Int> pointList3 = PieceContainer.LineMoveCreator("10000010", Side);
        MoveSet[2] = new Move(new PureAtttack(gridNode), pointList3);
    }
}
