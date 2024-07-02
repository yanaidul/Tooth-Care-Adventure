using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasienKarangGigi : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        if (!TryGetComponent(out Button button)) return;
        _button = button;
    }

    //Code untuk membuat button mini game melalui pasien setelah dokter sudah selesai bicara
    public void OnUnlockButton()
    {
        _button.interactable = true;
    }
}
