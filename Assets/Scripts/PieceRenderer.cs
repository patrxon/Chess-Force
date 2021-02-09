using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceRenderer : MonoBehaviour
{

    private readonly int _width = 8;
    private readonly int _height = 8;

    [SerializeField] private Sprite[] _figureSprites;
    private Dictionary<string, Sprite> _spriteDictionary;

    private GridNode[][] _gridNodes;

    public GameObject[][] Pieces { get; set; }

    void Start()
    {
        Pieces = new GameObject[_width][];

        for (int x = 0; x < _width; x++)
        {
            Pieces[x] = new GameObject[_height];

            for (int y = 0; y < _height; y++)
            {
                Pieces[x][y] = null;
            }
        }

        _spriteDictionary = new Dictionary<string, Sprite>();
        foreach (Sprite figure in _figureSprites)
        {
            _spriteDictionary[figure.name] = figure;
        }
    }

    public void SetGridNodes(GridNode[][] gridNodes) => _gridNodes = gridNodes;

    public void RefreshBoard()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                if (_gridNodes[x][y].Change)
                {
                    DestroyPiece(x, y);
                    if (_gridNodes[x][y].Piece != null)
                    {
                        AddPiece(_gridNodes[x][y].Piece, x, y);
                    }
                    _gridNodes[x][y].Change = false;
                }
            }
        }
    }

    public void AddPiece(Piece piece, int posx, int posy)
    {
        Transform parent = this.gameObject.transform;

        GameObject newPiece = new GameObject(piece.Name);
        Transform transform = newPiece.transform;
        transform.SetParent(parent);
        transform.localPosition = new Vector3(parent.position.x + posx - 0.5f, parent.position.y + posy - 0.5f , 0);
        transform.rotation = Quaternion.identity;

        newPiece.AddComponent(typeof(SpriteRenderer));
        SpriteRenderer spriteRenderer = newPiece.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = _spriteDictionary[piece.Name];

        if(piece.Side == -1)
        {
            spriteRenderer.color = new Color(0.2f, 0.2f, 0.2f);
        }

        Pieces[posx][posy] = newPiece;
    }
    
    public void DestroyPiece(int posx, int posy) => GameObject.Destroy(Pieces[posx][posy]);
    

}
