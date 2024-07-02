using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltrasonicScalerDetector : MonoBehaviour
{
    [SerializeField] private GameEventNoParam _onDetectKarangGigi;
    [SerializeField] private GameEventNoParam _onFinishCleaningKarangGigi;
    [SerializeField] private SpriteRenderer _onActionUltraSonicScalerSpriteRenderer;
    [SerializeField] private BoxCollider2D _onActionUltraSonicScalerBoxCollider;

    private Vector2 _initPos;

    private void Start()
    {
        _onActionUltraSonicScalerSpriteRenderer.gameObject.SetActive(false);
        _onActionUltraSonicScalerBoxCollider.enabled = true;
        _initPos = transform.localPosition;
    }

    //Code yang digunakan untuk mendeteksi gameobject yang memiliki tag "KarangGigi", dan melaksanakan animasi motion yang singkan lalu menghilangkan karang gigi
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KarangGigi"))
        {
            gameObject.transform.position = collision.transform.position;
            _onActionUltraSonicScalerBoxCollider.enabled = false;
            _onDetectKarangGigi.Raise();
            _onActionUltraSonicScalerSpriteRenderer.gameObject.SetActive(true);
            transform.DOMoveX(transform.position.x - 0.5f, 0.3f).SetLoops(3,LoopType.Yoyo).OnComplete(() =>
            {
                KarangGigiGameManager.GetInstance().RemoveKarangGigiFromList(collision.gameObject);
                collision.gameObject.SetActive(false);
                transform.localPosition = _initPos;
                _onActionUltraSonicScalerSpriteRenderer.gameObject.SetActive(false);
                _onActionUltraSonicScalerBoxCollider.enabled = true;
                _onFinishCleaningKarangGigi.Raise();
            });

        }
    }
}
