using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : MonoBehaviour
{
    [SerializeField] GameEventNoParam _onDoctorDoneSpeak;

    //Function yang dipanggil untuk membuat dokter ngomong
    public void OnDoctorSpeak(Animator animator)
    {
        SFXManager.GetInstance().OnDoctorSpeak();
        StartCoroutine(OnTriggerDelay(SFXManager.GetInstance()._sfxDokterSpeakIntro.length,animator));
    }

    //Functionyang dipanggil untuk membuat dokter idle
    IEnumerator OnTriggerDelay(float audioClipDuration,Animator animator)
    {
        yield return new WaitForSeconds(audioClipDuration);
        animator.SetBool("IsIdle", true);
        _onDoctorDoneSpeak.Raise();
    }

    //Funtion yang dipanggil ketika player klik skip button
    public void OnClickSkipButton()
    {
        if (SFXManager.GetInstance()._audioSource.isPlaying) SFXManager.GetInstance()._audioSource.Stop();
    }
}
