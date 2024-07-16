using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaKawatGigi : MonoBehaviour
{
    [SerializeField] private string _tagTarget;

    //Function yang dipanggil untuk mendeteksi kawat masuk di area cakupannya atau tidak, bila masuk area maka kawat akan terpasang dan menambahkan jumlah kawat yang terpasang
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_tagTarget))
        {
            collision.gameObject.SetActive(false);
            if (!TryGetComponent(out SpriteRenderer spriteRenderer)) return;
            spriteRenderer.enabled = true;
            PasangKawat.GetInstance().OnIncreaseJumlahKawatTerpasang();
        }
    }
}
