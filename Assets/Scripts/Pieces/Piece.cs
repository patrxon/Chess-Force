using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece
{
    public Move[] MoveSet { get; set; }
    public int Cost { get; set; }
    public string Name { get; set; }
    public int Side { get; set; }
    public int MovesMade { get; set; } = 0;
    public Vector2Int Position { get; set; }
    protected PieceContainer PieceContainer { get; }

    public Piece(int side)
    {
        Side = side;
        PieceContainer = new PieceContainer();
    }

    public bool MakeMove(GridNode selectedNode, Vector2Int destination)
    {
        foreach (Move move in MoveSet)
        {
            foreach (Vector2Int point in move.PointList)
            {
                if (point + selectedNode.Position == destination)
                {
                    if (move.MoveType.TestMove(selectedNode, destination))
                    {
                        move.MoveType.MakeMove(selectedNode, destination);
                        return true;
                    }
                }
            }
        }

        return false;
    }

    public Dictionary<string, List<Vector2Int>> GetLegalMoves(GridNode selectedNode)
    {
        Dictionary<string, List<Vector2Int>> legalMoves = new Dictionary<string, List<Vector2Int>>();

        foreach (Move move in MoveSet)
        {
            List<Vector2Int> legalMove = new List<Vector2Int>();

            foreach (Vector2Int point in move.PointList)
            {
                Vector2Int destination = point + selectedNode.Position;
                if (move.MoveType.TestMove(selectedNode, destination))
                {
                    legalMove.Add(destination);
                }
            }

            legalMoves[move.MoveType.MoveName] = legalMove;
        }

        return legalMoves;
    }

    public virtual void EndTurnEffect() { }
    public virtual void StartTurnEffect() { }
    public virtual void AfterMoveEffect() { }
    public virtual void AfterKillEffect() { }
    public virtual void AfterDeathEffect() { }
}
