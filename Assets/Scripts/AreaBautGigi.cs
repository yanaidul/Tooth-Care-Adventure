using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaBautGigi : MonoBehaviour
{
    [SerializeField] private string _tagTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(_tagTarget))
        {
            collision.gameObject.SetActive(false);
            if (!TryGetComponent(out SpriteRenderer spriteRenderer)) return;
            spriteRenderer.enabled = true;
            PasangBaut.GetInstance().OnIncreaseJumlahBautTerpasang();
        }
    }
}
