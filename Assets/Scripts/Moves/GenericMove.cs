using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericMove : IMoveType
{
    public string MoveName { get; set; }
    public GridNode[][] GridNodes;
    public bool attack;
    public bool magic = false;

    public abstract void MakeMove(GridNode selectedNode, Vector2Int destination);
    public abstract bool TestMove(GridNode selectedNode, Vector2Int destination);

    public bool IsInBounds(GridNode selectedNode, Vector2Int destination) => (0 <= destination.x && destination.x < 8 && 0 <= destination.y && destination.y < 8);
    
    public bool IsSpaceEmpty(GridNode selectedNode, Vector2Int destination) => GridNodes[destination.x][destination.y].Piece == null;
    
    public bool IsOnSameSide(GridNode selectedNode, Vector2Int destination) => GridNodes[destination.x][destination.y].Piece.Side == selectedNode.Piece.Side;
    
    public bool DidMove(GridNode selectedNode, Vector2Int destination) => selectedNode.Piece.MovesMade > 0;
    
    public bool IsPathFree(GridNode selectedNode, Vector2Int destination)
    {
        Vector2Int nextPos = selectedNode.Position;
        Vector2Int direction = (destination - nextPos);
        direction.Clamp(new Vector2Int(-1, -1), new Vector2Int(1, 1));

        nextPos = nextPos + direction;
        while (destination != nextPos)
        {
            if (GridNodes[nextPos.x][nextPos.y].Piece != null)
            {
                return false;
            }
            nextPos = nextPos + direction;
        }
        return true;
    }


}
