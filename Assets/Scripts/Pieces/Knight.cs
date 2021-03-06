﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    public Knight(int side) : base(side)
    {
        this.Name = "Knight";
        this.Cost = 6;
    }

    public override void SetupMoves()
    {
        MoveSet = new Move[1];

        List<Vector2Int> pointList = PieceContainer.PointMoveCreator(new List<(int, int)> { (1, 2), (-1, 2), (2, 1), (2, -1), (-2, 1), (-2, -1), (1, -2), (-1, -2) }, Side);
        MoveSet[0] = new Move(new JumpAttackMove(), pointList);
    }
}
