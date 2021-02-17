using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveType
{
    string MoveName { get; set; }

    void MakeMove(GridNode selectedNode, Vector2Int destination);
    bool TestMove(GridNode selectedNode, Vector2Int destination);
    bool TestAttacking(GridNode selectedNode, Vector2Int destination);

}
