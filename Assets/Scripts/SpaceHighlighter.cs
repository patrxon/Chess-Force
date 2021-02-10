using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceHighlighter : MonoBehaviour
{
    private readonly int _width = 8;
    private readonly int _height = 8;

    private GridNode[][] _gridNodes;

    private GameObject[][] _whiteHighlights;
    private GameObject[][] _blackHighlights;

    [SerializeField] private Sprite _highlight;

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
                        _whiteHighlights[destination.x][destination.y].GetComponent<SpriteRenderer>().enabled = true;       
                    }
                    else
                    {
                        _blackHighlights[destination.x][destination.y].GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
            }
        }
    }

    private void ResetHighlights()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                _whiteHighlights[x][y].GetComponent<SpriteRenderer>().enabled = false;
                _blackHighlights[x][y].GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    private void SetupWhiteHighlights()
    {
        _whiteHighlights = new GameObject[_width][];

        for (int x = 0; x < _width; x++)
        {
            _whiteHighlights[x] = new GameObject[_height];

            for (int y = 0; y < _height; y++)
            {
                _whiteHighlights[x][y] = MakeHighlight(x, y, 1);
            }
        }
    }
    private void SetupBlackHighlights()
    {
        _blackHighlights = new GameObject[_width][];

        for (int x = 0; x < _width; x++)
        {
            _blackHighlights[x] = new GameObject[_height];

            for (int y = 0; y < _height; y++)
            {
                _blackHighlights[x][y] = MakeHighlight(x, y, -1);
            }
        }
    }

    private GameObject MakeHighlight(int posx, int posy, int side)
    {
        Transform parent = this.gameObject.transform;

        GameObject newHighlight = new GameObject("hl:" + posx + "," + posy);
        Transform transform = newHighlight.transform;
        transform.SetParent(parent);
        transform.localPosition = new Vector3(parent.position.x + posx - 0.5f, parent.position.y + posy - 0.5f, 0);
        transform.rotation = Quaternion.identity;

        newHighlight.AddComponent(typeof(SpriteRenderer));
        SpriteRenderer spriteRenderer = newHighlight.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = _highlight;

        if (side == -1)
        {
            spriteRenderer.color = new Color(1f, 0f, 0f, 0.1f);
            transform.Rotate(0, 0, 90, Space.Self);
        }
        else
        {
            spriteRenderer.color = new Color(0f, 0f, 1f, 0.1f);
        }

        spriteRenderer.enabled = false;

        return newHighlight;
    }




}
