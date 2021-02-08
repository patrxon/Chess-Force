using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceRenderer : MonoBehaviour
{

    [SerializeField] int width = 8;
    [SerializeField] int height = 8;

    [SerializeField] Sprite[] figureSprites;
    private Dictionary<string, Sprite> spriteDictionary;

    GridNode[,] gridNodes;
    GameObject[,] pieces;

    int count = 0;

   
    void Start()
    {
        pieces = new GameObject[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                pieces[x, y] = null;
            }
        }

        spriteDictionary = new Dictionary<string, Sprite>();
        foreach (Sprite figure in figureSprites)
        {
            spriteDictionary[figure.name] = figure;
        }
    }

    public GameObject[,] GetPieces()
    {
        return pieces;
    }

    public void SetGridNodes(GridNode[,] gridNodes)
    {
        this.gridNodes = gridNodes;
    }

    public void RefreshBoard()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (gridNodes[x, y].change)
                {
                    DestroyPiece(x, y);
                    if (gridNodes[x, y].piece != null)
                    {
                        AddPiece(gridNodes[x, y].piece, x, y);
                    }
                    gridNodes[x, y].change = false;
                }
            }
        }
    }

    public void AddPiece(Piece piece, int posx, int posy)
    {
        Transform parent = this.gameObject.transform;

        GameObject newPiece = new GameObject(piece.name);
        count++;
        Transform transform = newPiece.transform;
        transform.SetParent(parent);
        transform.localPosition = new Vector3(parent.position.x + posx - 0.5f, parent.position.y + posy - 0.5f , 0);
        transform.rotation = Quaternion.identity;

        newPiece.AddComponent(typeof(SpriteRenderer));
        SpriteRenderer spriteRenderer = newPiece.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteDictionary[piece.name];

        if(piece.side == -1)
        {
            spriteRenderer.color = new Color(0.2f, 0.2f, 0.2f);
        }

        pieces[posx,posy] = newPiece;
    }
    
    public void DestroyPiece(int posx, int posy)
    {
        GameObject.Destroy(pieces[posx, posy]);
    }

}
