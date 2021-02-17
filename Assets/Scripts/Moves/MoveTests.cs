using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoveTests
{
    public static bool IsInBounds(this GridNode selectedNode, Vector2Int destination) => (0 <= destination.x && destination.x < 8 && 0 <= destination.y && destination.y < 8);
    public static bool DidMove(this GridNode selectedNode, Vector2Int destination) => selectedNode.Piece.MovesMade > 0;
    public static bool IsSpaceEmpty(this GridNode selectedNode, Vector2Int destination, bool ignoreSpace) => !(ignoreSpace || !(SpaceManager.GridNodes[destination.x][destination.y].Piece == null));
    public static bool IsOnSameSide(this GridNode selectedNode, Vector2Int destination, bool ignoreSpace) => !(ignoreSpace || !(SpaceManager.GridNodes[destination.x][destination.y].Piece.Side == selectedNode.Piece.Side));

    public static bool IsPathFree(this GridNode selectedNode, Vector2Int destination)
    {
        Vector2Int nextPos = selectedNode.Position;
        Vector2Int direction = (destination - nextPos);
        direction.Clamp(new Vector2Int(-1, -1), new Vector2Int(1, 1));

        nextPos = nextPos + direction;
        while (destination != nextPos)
        {
            if (SpaceManager.GridNodes[nextPos.x][nextPos.y].Piece != null)
            {
                return false;
            }
            nextPos += direction;
        }
        return true;
    }
}
