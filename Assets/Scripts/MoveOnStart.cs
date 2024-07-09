using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveOnStart : MonoBehaviour
{
    [SerializeField] private float _animationDuration = 2f;
    [SerializeField] private Animator _animator;

    private RectTransform _rectTransform;
    private Doctor _doctor;
    private float _initialXPos;

    private Tween _moveTween;

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

        _moveTween = _rectTransform.DOAnchorPosX(_initialXPos, _animationDuration).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            _animator.SetBool("IsTalk", true);
            _doctor.OnDoctorSpeak(_animator);
        });
    }

    public void OnClickSkipButton()
    {
        _moveTween.Kill();
        _animator.SetBool("IsTalk", true);
        _animator.SetBool("IsIdle", true);
        _rectTransform.anchoredPosition = new Vector2(_initialXPos, _rectTransform.anchoredPosition.y);
    }
}
