using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveOnStart : MonoBehaviour
{
    [SerializeField] private float _animationDuration = 2f;

    private RectTransform _rectTransform;
    private Doctor _doctor;
    private float _initialXPos;

    private void Awake()
    {
        if (!TryGetComponent(out RectTransform rectTransform)) return;
        _rectTransform = rectTransform;

        if (!TryGetComponent(out Doctor doctor)) return;
        _doctor = doctor;
    }

    //Code untuk membuat dokter berjalan dari kanan ke kiri
    void Start()
    {
        _initialXPos = _rectTransform.anchoredPosition.x;
        _rectTransform.anchoredPosition = new Vector2(_initialXPos + 500, _rectTransform.anchoredPosition.y);

        _rectTransform.DOAnchorPosX(_initialXPos, _animationDuration).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            _doctor.OnDoctorSpeak();
        });
    }
}
