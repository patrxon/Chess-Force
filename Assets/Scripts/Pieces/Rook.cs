using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    public Rook(int side) : base(side)
    {
        this.Name = "Rook";
        this.Cost = 8;
    }

    public override void SetupMoves()
    {
        MoveSet = new Move[1];

        List<Vector2Int> pointList = PieceContainer.LineMoveCreator("07070707", Side);
        MoveSet[0] = new Move(new AttackMove(), pointList);
    }
}
