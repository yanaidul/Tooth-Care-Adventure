using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : Singleton<BGM>
{
    public AudioSource bgm;

    private void Start()
    {
        bgm.Stop();
    }
}
