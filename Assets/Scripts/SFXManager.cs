using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : Singleton<SFXManager>
{
    public AudioSource _audioSource;

    [Header("Game Selection")]
    public AudioClip _sfxDokterSpeakIntro;

    [Header("Karang Gigi")]
    public AudioClip _sfxKarangGigiIntro;
    public AudioClip _sfxUltrasonicScaler;
    public AudioClip _sfxOutroKarangGigiLaluWinScreen;

    [Header("Cabut Gigi")]
    public AudioClip _sfxCabutGigiIntro;
    public AudioClip _sfxScanSelesai;
    public AudioClip _sfxTahapTang;
    public AudioClip _sfxTahapPasangBaut;
    public AudioClip _sfxTahapPasangGigi;
    public AudioClip _sfxCabutGigiOutro;

    [Header("Other")]
    public AudioClip _onWinSFX;

    //Buat scene game selection
    public void OnDoctorSpeak()
    {
        if (_audioSource.isPlaying) _audioSource.Stop();
        _audioSource.PlayOneShot(_sfxDokterSpeakIntro);
    }

    //Buat scene game karang gigi
    public void OnKarangGigiIntro()
    {
        if (_audioSource.isPlaying) _audioSource.Stop();
        _audioSource.PlayOneShot(_sfxKarangGigiIntro);
    }

    //Voice over akan aktif ketika ultrasonic scale di drag
    public void OnClickUltrasonicScaler()
    {
        if (_audioSource.isPlaying) _audioSource.Stop();
        _audioSource.PlayOneShot(_sfxUltrasonicScaler);
    }

    //Voice over akan aktif ketika game karang gigi sudah selesai
    public void OnKarangGigiOutro()
    {
        if (_audioSource.isPlaying) _audioSource.Stop();
        _audioSource.PlayOneShot(_sfxOutroKarangGigiLaluWinScreen);
    }

    //Buat scene game karang gigi
    public void OnCabutGigiIntro()
    {
        if (_audioSource.isPlaying) _audioSource.Stop();
        _audioSource.PlayOneShot(_sfxCabutGigiIntro);
    }

    //Voice over akan aktif ketika scan gigi berlubang sudah selesai
    public void OnScanGigiSelesai()
    {
        if (_audioSource.isPlaying) _audioSource.Stop();
        _audioSource.PlayOneShot(_sfxScanSelesai);
    }

    //Voice over akan aktif tang bisa di drag
    public void OnTahapTang()
    {
        if (_audioSource.isPlaying) _audioSource.Stop();
        _audioSource.PlayOneShot(_sfxTahapTang);
    }

    //Voice over akan aktif ketika game pasang baut mulai
    public void OnPasangBaut()
    {
        if (_audioSource.isPlaying) _audioSource.Stop();
        _audioSource.PlayOneShot(_sfxTahapPasangBaut);
    }

    //Voice over akan aktif ketika game pasang gigi mulai
    public void OnPasangGigi()
    {
        if (_audioSource.isPlaying) _audioSource.Stop();
        _audioSource.PlayOneShot(_sfxTahapPasangGigi);
    }

    //Voice over akan aktif ketika game cabut gigi sudah selesai
    public void OnCabutGigiOutro()
    {
        if (_audioSource.isPlaying) _audioSource.Stop();
        _audioSource.PlayOneShot(_sfxCabutGigiOutro);
    }

    //Other
    public void OnWinSFX()
    {
        if (_audioSource.isPlaying) _audioSource.Stop();
        _audioSource.PlayOneShot(_onWinSFX);
    }
}
