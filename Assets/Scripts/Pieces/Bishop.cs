using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    public Bishop(int side) : base(side)
    {
        this.Name = "Bishop";
        this.Cost = 6;
    }

    public override void SetupMoves()
    {
        MoveSet = new Move[1];

        List<Vector2Int> pointList = PieceContainer.LineMoveCreator("70707070", Side);
        MoveSet[0] = new Move(new AttackMove(), pointList);
    }
}
