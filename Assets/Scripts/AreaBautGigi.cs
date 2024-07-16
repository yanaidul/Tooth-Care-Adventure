using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaBautGigi : MonoBehaviour
{
    [SerializeField] private string _tagTarget;

    //Function yang dipanggil untuk mendeteksi Baut Gigi masuk di area cakupannya atau tidak, bila masuk area maka baut akan hilang dan menambahkan jumlah baut yang terpasang
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
