using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _onWinSFX;

    public void OnWinSFX()
    {
        _audioSource.PlayOneShot(_onWinSFX);
    }
}
