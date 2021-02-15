using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceHighlighter : MonoBehaviour
{
    private readonly int _width = 8;
    private readonly int _height = 8;

    private GridNode[][] _gridNodes;

    private SpriteRenderer[][] _whiteHighlights;
    private SpriteRenderer[][] _blackHighlights;

    [SerializeField] private Sprite _highlightWhite;
    [SerializeField] private Sprite _highlightBlack;

    void Start()
    {
        SetupWhiteHighlights();
        SetupBlackHighlights();
    }

    public void SetupGrid(GridNode[][] gridNodes) => _gridNodes = gridNodes;

    public void ShowControl()
    {
        ResetHighlights();
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                if (_gridNodes[x][y].Piece != null)
                {
                    CheckNode(_gridNodes[x][y]);
                }
            }
        }
    }

    private void CheckNode(GridNode gridNode)
    {
        Piece piece = gridNode.Piece;
        Color increment = new Color(0f, 0f, 0f, 0.1f);

        foreach (Move move in piece.MoveSet)
        {
            List<Vector2Int> legalMove = new List<Vector2Int>();

            foreach (Vector2Int point in move.PointList)
            {
                Vector2Int destination = point + gridNode.Position;
                if (move.MoveType.TestAttacking(gridNode, destination))
                {
                    if (piece.Side == 1)
                    {
                        _whiteHighlights[destination.x][destination.y].enabled = true;
                        _whiteHighlights[destination.x][destination.y].color += increment;
                    }
                    else
                    {
                        _blackHighlights[destination.x][destination.y].enabled = true;
                        _blackHighlights[destination.x][destination.y].color += increment;
                    }
                }
            }
        }
    }

    private void ResetHighlights()
    {
        Color red = new Color(1f, 0f, 0f, 0.2f);
        Color blue = new Color(0f, 0f, 1f, 0.2f);

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                _whiteHighlights[x][y].enabled = false;
                _whiteHighlights[x][y].color = blue;
                _blackHighlights[x][y].enabled = false;
                _blackHighlights[x][y].color = red;
            }
        }
    }

    private void SetupWhiteHighlights()
    {
        _whiteHighlights = new SpriteRenderer[_width][];

        for (int x = 0; x < _width; x++)
        {
            _whiteHighlights[x] = new SpriteRenderer[_height];

            for (int y = 0; y < _height; y++)
            {
                _whiteHighlights[x][y] = MakeHighlight(x, y, 1);
            }
        }
    }
    private void SetupBlackHighlights()
    {
        _blackHighlights = new SpriteRenderer[_width][];

        for (int x = 0; x < _width; x++)
        {
            _blackHighlights[x] = new SpriteRenderer[_height];

            for (int y = 0; y < _height; y++)
            {
                _blackHighlights[x][y] = MakeHighlight(x, y, -1);
            }
        }
    }

    private SpriteRenderer MakeHighlight(int posx, int posy, int side)
    {
        Transform parent = this.gameObject.transform;

        GameObject newHighlight = new GameObject("hl:" + posx + "," + posy);
        Transform transform = newHighlight.transform;
        transform.SetParent(parent);
        transform.localPosition = new Vector3(parent.position.x + posx - 0.5f, parent.position.y + posy - 0.5f, 0);
        transform.rotation = Quaternion.identity;

        newHighlight.AddComponent(typeof(SpriteRenderer));
        SpriteRenderer spriteRenderer = newHighlight.GetComponent<SpriteRenderer>();
       
        if (side == -1)
        {
            spriteRenderer.sprite = _highlightBlack;
            spriteRenderer.color = new Color(1f, 0f, 0f, 0.2f);
        }
        else
        {
            spriteRenderer.sprite = _highlightWhite;
            spriteRenderer.color = new Color(0f, 0f, 1f, 0.2f);
        }

        spriteRenderer.enabled = false;

        return spriteRenderer;
    }




}
