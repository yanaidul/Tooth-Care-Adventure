using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaGigi : MonoBehaviour
{
    [SerializeField] private string _tagTarget;
    [SerializeField] private GameObject _kawatReference;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_tagTarget))
        {
            _kawatReference.SetActive(false);
            collision.gameObject.SetActive(false);
            if (!TryGetComponent(out SpriteRenderer spriteRenderer)) return;
            spriteRenderer.enabled = true;
            PasangGigi.GetInstance().OnIncreaseJumlahGigiTerpasang();
        }
    }
}
