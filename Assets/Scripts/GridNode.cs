using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridNode
{
    public Vector2Int position { get; set; }
    public Piece piece { get; set; } = null;
    public bool change { get; set; } = true;

    public GridNode(int x, int y)
    {
        position = new Vector2Int(x, y);
        piece = null;
    }

    public void MovePiece(Piece piece)
    {
        this.piece = piece;
        change = true;
    }

}
