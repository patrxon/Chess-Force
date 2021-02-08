using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceManager : MonoBehaviour
{

    [SerializeField] int width = 8;
    [SerializeField] int height = 8;

    GridNode[,] gridNodes;
    GameObject[,] pieces;

    [SerializeField] PieceRenderer pieceRenderer;
    [SerializeField] MoveRenderer moveRenderer;
    [SerializeField] SelectorControler selectorControler;
    MouseController mouseController;
    
    GridNode selectedNode = null;
    bool followPiece = false;
    Vector2 onClickOffset;

    void Start()
    {
        gridNodes = new GridNode[width, height];
        mouseController = new MouseController(width, height);
        InitGrid();
    }

    void InitGrid()
    {
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                gridNodes[x, y] = new GridNode(x, y);
                
            }
        }
    }

    void TestStart()
    {
        pieces = pieceRenderer.GetPieces();
        pieceRenderer.SetGridNodes(gridNodes);
        moveRenderer.SetGridNodes(gridNodes);

        setupBoard(1, 1, 0);
        setupBoard(-1, 6, 7);

        pieceRenderer.RefreshBoard();
    }

    void  setupBoard(int side, int lp, int lf)
    {
        for (int i = 1; i < 7; i++)
        {
            gridNodes[i, lp].piece = new Pawn(side, gridNodes);
        }

        gridNodes[0, lp].piece = new Squire(side, gridNodes);
        gridNodes[7, lp].piece = new Fort(side, gridNodes);
        gridNodes[0, lf].piece = new Rook(side, gridNodes);
        gridNodes[1, lf].piece = new Knight(side, gridNodes);
        gridNodes[2, lf].piece = new Bishop(side, gridNodes);
        gridNodes[3, lf].piece = new Queen(side, gridNodes);
        gridNodes[4, lf].piece = new King(side, gridNodes);
        gridNodes[5, lf].piece = new Bishop(side, gridNodes);
        gridNodes[6, lf].piece = new Knight(side, gridNodes);
        gridNodes[7, lf].piece = new Rook(side, gridNodes);
    }

    [SerializeField] bool makeTest = false;

    void Update()
    {
        if(makeTest)
        {
            makeTest = false;
            TestStart();       
        }

        if(Input.GetMouseButtonDown(0))
        {
            GrabPiece();
        }

        if(followPiece)
        {
            FollowMouse();
        }

        if(Input.GetMouseButtonUp(0))
        {
            if (selectedNode != null)
            {
                ReleasPiece();
            }
        }
    }

    private void GrabPiece()
    {
        Vector2Int mousePos = mouseController.GetPosInGrid();

        if (mouseController.IsMouseInGrid(mousePos) && gridNodes[mousePos.x, mousePos.y].piece != null)
        {
            selectedNode = gridNodes[mousePos.x, mousePos.y];
            moveRenderer.showMoves(selectedNode);
            selectorControler.SelectPiece(mousePos);
            followPiece = true;
            onClickOffset = mouseController.GetFloatPosInGrid() - mousePos;
        }
    }

    private void ReleasPiece()
    {
        Vector2Int mousePos = mouseController.GetPosInGrid();
        followPiece = false;

        Vector2Int prevPos = selectedNode.position;
        pieces[prevPos.x, prevPos.y].transform.localPosition = new Vector3(prevPos.x, prevPos.y, 0);

        if (mouseController.IsMouseInGrid(mousePos) && selectedNode != null)
        {
            Piece piece = selectedNode.piece;
            
            bool moved = piece.MakeMove(selectedNode, mousePos);
 
            if (moved)
            {
                pieceRenderer.RefreshBoard();
                selectorControler.HideSelector();
                moveRenderer.HideMoves();
                selectedNode = null;
            }
        }
    }

    private void FollowMouse()
    {
        Vector2Int prevPos = selectedNode.position;
        Vector2 mousePos = mouseController.GetFloatPosInGrid();

        Vector3 newPos = new Vector3(mousePos.x - onClickOffset.x, mousePos.y - onClickOffset.y, -2);

        pieces[prevPos.x, prevPos.y].transform.localPosition = newPos;
    }


}
