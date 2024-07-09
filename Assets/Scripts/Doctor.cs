using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : MonoBehaviour
{
    [SerializeField] GameEventNoParam _onDoctorDoneSpeak;

    public void OnDoctorSpeak(Animator animator)
    {
        SFXManager.GetInstance().OnDoctorSpeak();
        StartCoroutine(OnTriggerDelay(SFXManager.GetInstance()._sfxDokterSpeakIntro.length,animator));
    }

    IEnumerator OnTriggerDelay(float audioClipDuration,Animator animator)
    {
        yield return new WaitForSeconds(audioClipDuration);
        animator.SetBool("IsIdle", true);
        _onDoctorDoneSpeak.Raise();
    }

    public void OnClickSkipButton()
    {
        if (SFXManager.GetInstance()._audioSource.isPlaying) SFXManager.GetInstance()._audioSource.Stop();
    }
}
