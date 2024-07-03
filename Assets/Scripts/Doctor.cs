using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : MonoBehaviour
{
    [SerializeField] GameEventNoParam _onDoctorDoneSpeak;

    public void OnDoctorSpeak()
    {
        SFXManager.GetInstance().OnDoctorSpeak();
        StartCoroutine(OnTriggerDelay(SFXManager.GetInstance()._sfxDokterSpeakIntro.length));
    }

    IEnumerator OnTriggerDelay(float audioClipDuration)
    {
        yield return new WaitForSeconds(audioClipDuration);
        _onDoctorDoneSpeak.Raise();
    }
}
