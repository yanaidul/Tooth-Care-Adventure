using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nampan : MonoBehaviour
{
    [SerializeField] private GameObject _gigiBerlubang1InNampan;
    [SerializeField] private GameObject _gigiBerlubang2InNampan;
    [SerializeField] private TangDetector _tangDetector;
    [SerializeField] private GameEventNoParam _onNampanGigiBerlubangFull;
    private int _isiNampan;
    private Vector2 _initPos;
    private void Start()
    {
        _initPos = transform.position;
        transform.position = new Vector2(transform.position.x, transform.position.y - 10);
        transform.DOMoveY(_initPos.y, 1).OnComplete(() =>
        {
            SFXManager.GetInstance().OnTahapTang();
        });
        _gigiBerlubang1InNampan.SetActive(false);
        _gigiBerlubang2InNampan.SetActive(false);
        _isiNampan = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GigiBerlubang1"))
        {
            _gigiBerlubang1InNampan.gameObject.SetActive(true);
            collision.gameObject.SetActive(false);
            _tangDetector.SetIsHoldingAToothValue(false);
            _isiNampan++;

            if (_isiNampan >= 2)
            {
                transform.DOMoveY(transform.position.y - 10, 1).SetDelay(2);
                _onNampanGigiBerlubangFull.Raise();
            }
        }

        if (collision.CompareTag("GigiBerlubang2"))
        {
            _gigiBerlubang2InNampan.gameObject.SetActive(true);
            collision.gameObject.SetActive(false);
            _tangDetector.SetIsHoldingAToothValue(false);
            _isiNampan++;

            if (_isiNampan >= 2)
            {
                transform.DOMoveY(transform.position.y - 10, 1).SetDelay(2);
                _onNampanGigiBerlubangFull.Raise();
            }
        }


    }
}
