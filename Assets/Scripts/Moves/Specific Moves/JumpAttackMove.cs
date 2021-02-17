using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttackMove : GenericMove
{
    public JumpAttackMove()
    {
        MoveName = "JumpAttackMove";
        attack = true;
    }

    public override void MakeMove(GridNode selectedNode, Vector2Int destination)
    {
        Vector2Int source = selectedNode.Position;
        Piece piece = SpaceManager.GridNodes[source.x][source.y].Piece;
        SpaceManager.GridNodes[destination.x][destination.y].MovePiece(piece);
        SpaceManager.GridNodes[source.x][source.y].MovePiece(null);
        piece.MovesMade += 1;
    }

    public override bool TestMove(GridNode selectedNode, Vector2Int destination)
    {
        if (!selectedNode.IsInBounds(destination))
        {
            return false;
        }
        
        if (!selectedNode.IsSpaceEmpty(destination, ignoreSpace) && selectedNode.IsOnSameSide(destination, ignoreSpace))
        {
            return false;
        }

        return true;
    }
}
