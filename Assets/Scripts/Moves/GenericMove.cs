using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericMove : IMoveType
{
    public string MoveName { get; set; }
    public bool attack = false;
    public bool magic = false;
    public bool ignoreSpace = false;

    public abstract void MakeMove(GridNode selectedNode, Vector2Int destination);
    public abstract bool TestMove(GridNode selectedNode, Vector2Int destination);

    public bool TestAttacking(GridNode selectedNode, Vector2Int destination)
    {
        if(!attack)
        {
            return false;
        }

        ignoreSpace = true;
        bool result = TestMove(selectedNode, destination);
        ignoreSpace = false;
        return result;
    }

    protected void MovePiece(GridNode selectedNode, Vector2Int destination)
    {
        Piece piece = selectedNode.Piece;
        SpaceManager.GridNodes[destination.x][destination.y].MovePiece(piece);
        selectedNode.MovePiece(null);

        piece.AfterMoveEffect();
    }

    protected void AttackPiece(GridNode selectedNode, Vector2Int destination)
    {

    }


}
