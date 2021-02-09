using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMove : GenericMove
{
    public AttackMove(GridNode[][] gridNodes)
    {
        GridNodes = gridNodes;
        MoveName = "AttackMove";
        attack = true;
    }

    public override void MakeMove(GridNode selectedNode, Vector2Int destination)
    {
        Vector2Int source = selectedNode.Position;
        Piece piece = GridNodes[source.x][source.y].Piece;
        GridNodes[destination.x][destination.y].MovePiece(piece);
        GridNodes[source.x][source.y].MovePiece(null);
        piece.MovesMade += 1;
    }

    public override bool TestMove(GridNode selectedNode, Vector2Int destination)
    {
        if (!IsInBounds(selectedNode, destination))
        {
            return false;
        }

        if(!IsSpaceEmpty(selectedNode, destination) && IsOnSameSide(selectedNode, destination))
        {
            return false;     
        }

        if(!IsPathFree(selectedNode, destination))
        {
            return false;
        }

        return true;
    }
}
