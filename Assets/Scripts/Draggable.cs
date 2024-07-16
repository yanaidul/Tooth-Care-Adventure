using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [SerializeField] private bool _isBaut = false;
    [SerializeField] private Sprite _bautBerdiri;

    //FUnction yang dipnaggil ketika object dengan script ini di drag
    public void OnClickObject()
    {
        if(_isBaut)
        {
            if (!TryGetComponent(out SpriteRenderer spriteRenderer)) return;
            spriteRenderer.sprite = _bautBerdiri;
        }
    }
}
