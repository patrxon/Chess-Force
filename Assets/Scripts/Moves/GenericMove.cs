using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericMove : MoveType
{
    public string moveName { get; set; }
    public GridNode[,] gridNodes;
    public bool attack;
    public bool magic = false;

    public abstract void MakeMove(GridNode selectedNode, Vector2Int destination);
    public abstract bool TestMove(GridNode selectedNode, Vector2Int destination);


    public bool IsInBounds(GridNode selectedNode, Vector2Int destination)
    {
        return 0 <= destination.x && destination.x < 8 && 0 <= destination.y && destination.y < 8;
    }

    public bool IsSpaceEmpty(GridNode selectedNode, Vector2Int destination)
    {
        return gridNodes[destination.x, destination.y].piece == null;
    }

    public bool IsOnSameSide(GridNode selectedNode, Vector2Int destination)
    {
        return gridNodes[destination.x, destination.y].piece.side == selectedNode.piece.side;
    }

    public bool DidMove(GridNode selectedNode, Vector2Int destination)
    {
        return selectedNode.piece.movesMade > 0;
    }

    public bool IsPathFree(GridNode selectedNode, Vector2Int destination)
    {
        Vector2Int nextPos = selectedNode.position;
        Vector2Int direction = (destination - nextPos);
        direction.Clamp(new Vector2Int(-1, -1), new Vector2Int(1, 1));

        nextPos = nextPos + direction;
        while (destination != nextPos)
        {
            if (gridNodes[nextPos.x, nextPos.y].piece != null)
            {
                return false;
            }
            nextPos = nextPos + direction;
        }
        return true;
    }
}
