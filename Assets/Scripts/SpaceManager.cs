using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceManager : MonoBehaviour
{

    private readonly int _width = 8;
    private readonly int _height = 8;
    [SerializeField] private PieceRenderer _pieceRenderer;
    [SerializeField] private MoveRenderer _moveRenderer;
    [SerializeField] private SelectorControler _selectorControler;
    [SerializeField] private SpaceHighlighter _spaceHighlighter;

    private GridNode[][] _gridNodes;
    private GameObject[][] _pieces;

    private MouseController _mouseController;
    private GridNode _selectedNode = null;

    bool followPiece = false; //temp
    Vector2 onClickOffset; //temp

    void Start()
    {
        _mouseController = new MouseController();
        InitGrid();
    }

    private void InitGrid()
    {
        _gridNodes = new GridNode[_width][];

        for (int x = 0; x < _width; x++)
        {
            _gridNodes[x] = new GridNode[_height];

            for (int y = 0; y < _height; y++)
            {
                _gridNodes[x][y] = new GridNode(x, y);
            }
        }
    }

    private void TestStart()
    {
        _pieces = _pieceRenderer.Pieces;
        _pieceRenderer.SetGridNodes(_gridNodes);
        _spaceHighlighter.SetupGrid(_gridNodes);

        SetupBoard(1, 1, 0);
        SetupBoard(-1, 6, 7);

        _spaceHighlighter.ShowControl();
        _pieceRenderer.RefreshBoard();
    }

    private void SetupBoard(int side, int lp, int lf)
    {
        for (int i = 1; i < 7; i++)
        {
            _gridNodes[i][lp].Piece = new Pawn(side, _gridNodes);
        }

        _gridNodes[0][lp].Piece = new Squire(side, _gridNodes);
        _gridNodes[7][lp].Piece = new Fort(side, _gridNodes);
        _gridNodes[0][lf].Piece = new Rook(side, _gridNodes);
        _gridNodes[1][lf].Piece = new Knight(side, _gridNodes);
        _gridNodes[2][lf].Piece = new Bishop(side, _gridNodes);
        _gridNodes[3][lf].Piece = new Queen(side, _gridNodes);
        _gridNodes[4][lf].Piece = new King(side, _gridNodes);
        _gridNodes[5][lf].Piece = new Bishop(side, _gridNodes);
        _gridNodes[6][lf].Piece = new Knight(side, _gridNodes);
        _gridNodes[7][lf].Piece = new Rook(side, _gridNodes);
    }

    [SerializeField] bool makeTest = false; //temp

    void Update()
    {
        if (makeTest)
        {
            makeTest = false;
            TestStart();
        }

        if (Input.GetMouseButtonDown(0))
        {
            GrabPiece();
        }

        if (followPiece)
        {
            FollowMouse();
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_selectedNode != null)
            {
                ReleasPiece();
            }
        }
    }

    private void GrabPiece()
    {
        Vector2Int mousePos = _mouseController.GetPosInGrid();

        if (_mouseController.IsMouseInGrid(mousePos) && _gridNodes[mousePos.x][mousePos.y].Piece != null)
        {
            _selectedNode = _gridNodes[mousePos.x][mousePos.y];
            _moveRenderer.showMoves(_selectedNode);
            _selectorControler.SelectPiece(mousePos);
            followPiece = true;
            onClickOffset = _mouseController.GetFloatPosInGrid() - mousePos;
        }
    }

    private void ReleasPiece()
    {
        Vector2Int mousePos = _mouseController.GetPosInGrid();
        followPiece = false;

        Vector2Int prevPos = _selectedNode.Position;
        _pieces[prevPos.x][prevPos.y].transform.localPosition = new Vector3(prevPos.x, prevPos.y, 0);

        if (_mouseController.IsMouseInGrid(mousePos) && _selectedNode != null)
        {
            Piece piece = _selectedNode.Piece;

            bool moved = piece.MakeMove(_selectedNode, mousePos);

            if (moved)
            {
                _pieceRenderer.RefreshBoard();
                _selectorControler.HideSelector();
                _moveRenderer.HideMoves();
                _spaceHighlighter.ShowControl();
                _selectedNode = null;
            }
        }
    }

    private void FollowMouse()
    {
        Vector2Int prevPos = _selectedNode.Position;
        Vector2 mousePos = _mouseController.GetFloatPosInGrid();

        Vector3 newPos = new Vector3(mousePos.x - onClickOffset.x, mousePos.y - onClickOffset.y, -2);

        _pieces[prevPos.x][prevPos.y].transform.localPosition = newPos;
    }


}
