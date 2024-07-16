using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasangGigi : Singleton<PasangGigi>
{
    private int _jumlahGigiTerpasang;
    [SerializeField] private GameObject _nampan;
    private Vector2 _initPos;

    private void Start()
    {
        _initPos = _nampan.transform.position;
        _nampan.transform.position = new Vector2(_nampan.transform.position.x, _nampan.transform.position.y - 10);
        _nampan.transform.DOMoveY(_initPos.y, 1).OnComplete(() =>
        {
            SFXManager.GetInstance().OnPasangGigi();
        }); ;
        _jumlahGigiTerpasang = 0;
    }

    //Function yang dipanggil untuk meningkatkat jumlah gigi yang terpasang, yang dimana kalau jumlah gigi terpasang sudah 2, maka akan lanjut ke tahap selanjutnya
    public void OnIncreaseJumlahGigiTerpasang()
    {
        _jumlahGigiTerpasang++;
        if (_jumlahGigiTerpasang >= 2)
        {
            _nampan.transform.DOMoveY(transform.position.y - 10, 1).SetDelay(2).OnComplete(() =>
            {
                CabutGigiGameManager.GetInstance().OnNextTahap();
            });

        }
    }
}
