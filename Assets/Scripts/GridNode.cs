using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridNode
{
    public Vector2Int Position { get; set; }
    public Piece Piece { get; set; } = null;
    public bool Change { get; set; } = true;

    public GridNode(int x, int y) => Position = new Vector2Int(x, y);
    
    public void MovePiece(Piece piece)
    {
        Piece = piece;
        Change = true;
    }

}
