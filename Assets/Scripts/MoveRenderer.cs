using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRenderer : MonoBehaviour
{
    [SerializeField] private Sprite[] _moveSprites;
    private List<GameObject> _moves;

    private Dictionary<string, Sprite> _spriteDictionary;

    void Start()
    {
        _moves = new List<GameObject>();
        _spriteDictionary = new Dictionary<string, Sprite>();
        foreach (Sprite figure in _moveSprites)
        {
            _spriteDictionary[figure.name] = figure;
        }
    }

    public void showMoves(GridNode selectedNode)
    {
        HideMoves();

        Piece selectedPiece = selectedNode.Piece;
        Dictionary<string, List<Vector2Int>> legalMoves = selectedPiece.GetLegalMoves(selectedNode);

        foreach (KeyValuePair<string, List<Vector2Int>> move in legalMoves)
        {
            foreach (Vector2Int point in move.Value)
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
        spriteRenderer.sprite = _spriteDictionary[moveType];

        _moves.Add(newMove);
    }

    public void HideMoves()
    {
        foreach (GameObject move in _moves)
        {
            GameObject.Destroy(move);
        }
    }
}
