using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : MonoBehaviour
{
    [SerializeField] GameEventNoParam _onDoctorDoneSpeak;

    public void OnDoctorSpeak()
    {
        _onDoctorDoneSpeak.Raise();
    }
}
