using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltrasonicScaler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _mainSpriteRenderer;
    [SerializeField] private BoxCollider2D _mainBoxCollider;

    private void Start()
    {
        _mainBoxCollider.enabled = true;
        _mainSpriteRenderer.enabled = true;
    }

    //Code yang dipanggil ketika alat mendeteksi karang gigi
    public void OnDetectKarangGigi()
    {
        _mainBoxCollider.enabled = false;
        _mainSpriteRenderer.enabled = false;
    }

    //Code yang dipanggil ketika alat sudah menghilangkan karang gigi
    public void OnFinishCleaningKarangGigi()
    {
        _mainBoxCollider.enabled = true;
        _mainSpriteRenderer.enabled = true;
    }
}
