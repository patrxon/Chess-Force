using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    public Queen(int side) : base(side)
    {
        this.Name = "Queen";
        this.Cost = 10;
    }

    public override void SetupMoves()
    {
        MoveSet = new Move[1];

        List<Vector2Int> pointList = PieceContainer.LineMoveCreator("77777777", Side);
        MoveSet[0] = new Move(new AttackMove(), pointList);
    }
}
