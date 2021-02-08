﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MoveType
{
    string moveName { get; set; }
    void MakeMove(GridNode selectedNode, Vector2Int destination);
    bool TestMove(GridNode selectedNode, Vector2Int destination);

    bool IsInBounds(GridNode selectedNode, Vector2Int destination);
    bool IsSpaceEmpty(GridNode selectedNode, Vector2Int destination);
    bool IsOnSameSide(GridNode selectedNode, Vector2Int destination);
    bool IsPathFree(GridNode selectedNode, Vector2Int destination);
    bool DidMove(GridNode selectedNode, Vector2Int destination);
}