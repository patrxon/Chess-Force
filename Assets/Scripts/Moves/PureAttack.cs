using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PureAtttack : GenericMove
{
    public PureAtttack(GridNode[][] gridNodes)
    {
        GridNodes = gridNodes;
        MoveName = "PureAttack";
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

        if(IsSpaceEmpty(selectedNode, destination))
        {
            return false;
        }

        if(IsOnSameSide(selectedNode, destination))
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
