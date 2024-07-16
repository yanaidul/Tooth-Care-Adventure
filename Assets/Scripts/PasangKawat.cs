using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasangKawat : Singleton<PasangKawat>
{
    private int _jumlahKawatTerpasang;
    [SerializeField] private GameObject _nampan;
    private Vector2 _initPos;

    private void Start()
    {
        _initPos = _nampan.transform.position;
        _nampan.transform.position = new Vector2(_nampan.transform.position.x, _nampan.transform.position.y - 10);
        _nampan.transform.DOMoveY(_initPos.y, 1);
        _jumlahKawatTerpasang = 0;
    }

    //Function yang dipanggil untuk meningkatkat jumlah kawat yang terpasang, yang dimana kalau jumlah kawat terpasang sudah 2, maka akan lanjut ke tahap selanjutnya
    public void OnIncreaseJumlahKawatTerpasang()
    {
        _jumlahKawatTerpasang++;
        if (_jumlahKawatTerpasang >= 2)
        {
            _nampan.transform.DOMoveY(transform.position.y - 10, 1).SetDelay(2).OnComplete(() =>
            {
                CabutGigiGameManager.GetInstance().OnNextTahap();
            });

        }
    }
}
