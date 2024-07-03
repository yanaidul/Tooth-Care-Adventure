using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerDetector : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _onActionUltraSonicScalerSpriteRenderer;
    [SerializeField] private BoxCollider2D _onActionUltraSonicScalerBoxCollider;

    private Vector2 _initPos;

    private void Start()
    {
        //_onActionUltraSonicScalerSpriteRenderer.gameObject.SetActive(false);
        //_onActionUltraSonicScalerBoxCollider.enabled = true;
        _initPos = transform.localPosition;
    }

    //Code yang digunakan untuk mendeteksi gameobject yang memiliki tag "KarangGigi", dan melaksanakan animasi motion yang singkan lalu menghilangkan karang gigi
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GigiBerlubang"))
        {
            Debug.Log("Detect Gigi Berlubang");
            //gameObject.transform.position = collision.transform.position;
            //_onActionUltraSonicScalerBoxCollider.enabled = false;
            //_onActionUltraSonicScalerSpriteRenderer.gameObject.SetActive(true);
            //transform.DOMoveX(transform.position.x - 0.5f, 0.3f).SetLoops(3, LoopType.Yoyo).OnComplete(() =>
            //{
            //    KarangGigiGameManager.GetInstance().RemoveKarangGigiFromList(collision.gameObject);
            //    collision.gameObject.SetActive(false);
            //    transform.localPosition = _initPos;
            //    _onActionUltraSonicScalerSpriteRenderer.gameObject.SetActive(false);
            //    _onActionUltraSonicScalerBoxCollider.enabled = true;
            //});

        }
    }
}
