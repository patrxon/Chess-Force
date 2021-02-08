using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece
{
    public Move[] moveSet { get; set; }
    public int cost { get; set; }
    public string name { get; set; }
    public int side { get; set; }
    public int movesMade { get; set; } = 0;
    protected PieceContainer pc { get; }

    public Piece(int side)
    {
        this.side = side;
        pc = new PieceContainer();
    }

    public bool MakeMove(GridNode selectedNode, Vector2Int destination)
    {
        foreach (Move move in moveSet)
        { 
            foreach (Vector2Int point in move.pointList)
            {
                if (point + selectedNode.position == destination)
                {
                    if (move.moveType.TestMove(selectedNode, destination))
                    {
                        move.moveType.MakeMove(selectedNode, destination);
                        return true;
                    }
                }
            }
        }

        return false;
    }

    public Dictionary<string, List<Vector2Int>> getLegalMoves(GridNode selectedNode)
    {
        Dictionary<string, List<Vector2Int>> legalMoves = new Dictionary<string, List<Vector2Int>>();

        foreach (Move move in moveSet)
        {
            List<Vector2Int> legalMove = new List<Vector2Int>();

            foreach (Vector2Int point in move.pointList)
            {
                Vector2Int destination = point + selectedNode.position;
                if (move.moveType.TestMove(selectedNode, destination))
                {
                    legalMove.Add(destination);
                }
            }
       
            legalMoves[move.moveType.moveName] = legalMove;
        }
         
        return legalMoves;
    }

    public virtual void EndTurnEffect() { }
    public virtual void StartTurnEffect() { }
    public virtual void AfterMoveEffect() { }
    public virtual void AfterKillEffect() { }
    public virtual void AfterDeathEffect() { }
}
