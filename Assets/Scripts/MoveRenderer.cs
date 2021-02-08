using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRenderer : MonoBehaviour
{
    [SerializeField] Sprite[] moveSprites;
    GridNode[,] gridNodes;
    List<GameObject> moves;

    private Dictionary<string, Sprite> spriteDictionary;

    void Start()
    {
        moves = new List<GameObject>();
        spriteDictionary = new Dictionary<string, Sprite>();
        foreach (Sprite figure in moveSprites)
        {
            spriteDictionary[figure.name] = figure;
        }
    }

    public void SetGridNodes(GridNode[,] gridNodes)
    {
        this.gridNodes = gridNodes;
    }

    public void showMoves(GridNode selectedNode)
    {
        HideMoves();

        Piece selectedPiece = selectedNode.piece;
        Dictionary<string, List<Vector2Int>> legalMoves = selectedPiece.getLegalMoves(selectedNode);

        foreach(KeyValuePair<string,List < Vector2Int >> move in legalMoves)
        {
            foreach(Vector2Int point in move.Value)
            {
                ShowMove(move.Key, point);
            }
        }

    }

    private void ShowMove(string moveType, Vector2Int position)
    {
        Transform parent = this.gameObject.transform;

        GameObject newMove = new GameObject(moveType);
        Transform transform = newMove.transform;
        transform.SetParent(parent);
        transform.localPosition = new Vector3(position.x, position.y, 0);
        transform.rotation = Quaternion.identity;

        newMove.AddComponent(typeof(SpriteRenderer));
        SpriteRenderer spriteRenderer = newMove.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteDictionary[moveType];

        moves.Add(newMove);
    }

    public void HideMoves()
    {
        foreach(GameObject move in moves)
        {
            GameObject.Destroy(move);
        }
    }
}
