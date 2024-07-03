using DG.Tweening;
using UnityEngine;

public class ScannerDetector : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _scannerCollider;
    [SerializeField] private SpriteRenderer _gigiBerlubang1;
    [SerializeField] private SpriteRenderer _gigiBerlubang2;
    private bool _justOnceDetect;

    private void Start()
    {
        _justOnceDetect = true;
    }

    //Code yang digunakan untuk mendeteksi gameobject yang memiliki tag "Gigi Berlubang"
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_justOnceDetect) return;
        if (collision.CompareTag("GigiBerlubang"))
        {
            Debug.Log("Detect Gigi Berlubang");
            _justOnceDetect = false;
            if (!transform.parent.TryGetComponent(out Draggable draggable)) return;
            draggable.enabled = false;
            DragController.GetInstance().SetDragActiveToFalse();
            _scannerCollider.enabled = false;
            _gigiBerlubang1.maskInteraction = SpriteMaskInteraction.None;
            _gigiBerlubang2.maskInteraction = SpriteMaskInteraction.None;
            transform.parent.DOMoveY(transform.position.y - 10, 1).SetDelay(2).OnComplete(() =>
            {
                CabutGigiGameManager.GetInstance().OnNextTahap();
            });
        }
    }
}
