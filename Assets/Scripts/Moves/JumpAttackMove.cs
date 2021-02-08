using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttackMove : GenericMove
{
    public JumpAttackMove(GridNode[,] gridNodes)
    {
        this.gridNodes = gridNodes;
        moveName = "JumpAttackMove";
        attack = true;
    }

    override
    public void MakeMove(GridNode selectedNode, Vector2Int destination)
    {
        Vector2Int source = selectedNode.position;
        Piece piece = gridNodes[source.x, source.y].piece;
        gridNodes[destination.x, destination.y].MovePiece(piece);
        gridNodes[source.x, source.y].MovePiece(null);
        piece.movesMade += 1;
    }

    override
    public bool TestMove(GridNode selectedNode, Vector2Int destination)
    {
        if (!IsInBounds(selectedNode, destination))
        {
            return false;
        }

        if (!IsSpaceEmpty(selectedNode, destination) && IsOnSameSide(selectedNode, destination))
        {
            return false;
        }

        return true;
    }
}
