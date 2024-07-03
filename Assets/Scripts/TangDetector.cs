using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangDetector : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _tangCollider;
    [SerializeField] private GameObject _gigiBerlubang1InTang;
    [SerializeField] private GameObject _gigiBerlubang2InTang;
    private bool _isHoldingATooth;

    private void Start()
    {
        _gigiBerlubang1InTang.SetActive(false);
        _gigiBerlubang2InTang.SetActive(false);
        _isHoldingATooth = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isHoldingATooth) return;
        if(collision.CompareTag("GigiBerlubang1"))
        {
            _gigiBerlubang1InTang.gameObject.SetActive(true);
            collision.gameObject.SetActive(false);
            _isHoldingATooth = true;
        }

        if (collision.CompareTag("GigiBerlubang2"))
        {
            _gigiBerlubang2InTang.gameObject.SetActive(true);
            collision.gameObject.SetActive(false);
            _isHoldingATooth = true;
        }
    }

    public void SetIsHoldingAToothValue(bool newValue)
    {
        _isHoldingATooth = newValue;
    }

    public void OnTangFinish()
    {
        if (!transform.parent.TryGetComponent(out Draggable draggable)) return;
        draggable.enabled = false;
        DragController.GetInstance().SetDragActiveToFalse();
        _tangCollider.enabled = false;
        transform.parent.DOMoveY(transform.parent.position.y - 10, 1).SetDelay(2).OnComplete(() =>
        {
            CabutGigiGameManager.GetInstance().OnNextTahap();
        }
        );
    }
}
