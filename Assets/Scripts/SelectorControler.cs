using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorControler : MonoBehaviour
{
    [SerializeField] GameObject selector;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = selector.GetComponent<SpriteRenderer>();
        HideSelector();
    }

    public void SelectPiece(Vector2Int pos)
    {
        selector.transform.localPosition = new Vector3(pos.x, pos.y, 0);
        spriteRenderer.enabled = true;
    }

    public void HideSelector()
    {
        spriteRenderer.enabled = false;
    }
    
}
