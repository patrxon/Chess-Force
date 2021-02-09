using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastMove : GenericMove
{
    public FastMove(GridNode[][] gridNodes)
    {
        GridNodes = gridNodes;
        MoveName = "FastMove";
        attack = false;
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

        if (!IsSpaceEmpty(selectedNode, destination))
        {
            return false;
        }

        if (DidMove(selectedNode,destination))
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
