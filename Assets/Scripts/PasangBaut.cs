using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasangBaut : Singleton<PasangBaut>
{
    private int _jumlahBautTerpasang;
    [SerializeField] private GameObject _nampan;
    private Vector2 _initPos;

    private void Start()
    {
        _initPos = _nampan.transform.position;
        _nampan.transform.position = new Vector2(_nampan.transform.position.x, _nampan.transform.position.y - 10);
        _nampan.transform.DOMoveY(_initPos.y, 1).OnComplete(() =>
        {
            SFXManager.GetInstance().OnPasangBaut();
        });
        _jumlahBautTerpasang = 0;
    }

    public void OnIncreaseJumlahBautTerpasang()
    {
        _jumlahBautTerpasang++;
        if(_jumlahBautTerpasang >= 2)
        {
            _nampan.transform.DOMoveY(transform.position.y - 10, 1).SetDelay(2).OnComplete(() =>
            {
                CabutGigiGameManager.GetInstance().OnNextTahap();
            });
            
        }
    }
}
