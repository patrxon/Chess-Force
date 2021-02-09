using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorControler : MonoBehaviour
{
    [SerializeField] private GameObject _selector;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = _selector.GetComponent<SpriteRenderer>();
        HideSelector();
    }

    public void SelectPiece(Vector2Int pos)
    {
        _selector.transform.localPosition = new Vector3(pos.x, pos.y, 0);
        _spriteRenderer.enabled = true;
    }

    public void HideSelector() => _spriteRenderer.enabled = false;
    
    
}
