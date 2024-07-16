using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarangGigiGameManager : Singleton<KarangGigiGameManager>
{
    [SerializeField] private List<GameObject> _karangGigiList = new();
    [SerializeField] private GameObject _worldGameObject;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameEventNoParam _onWin;
    [SerializeField] private GameObject _gamePanel;

    private void Start()
    {
        _worldGameObject.SetActive(true);
        SFXManager.GetInstance().OnKarangGigiIntro();
        StartCoroutine(OnTriggerDelayIntro(SFXManager.GetInstance()._sfxKarangGigiIntro.length));
        _winPanel.SetActive(false);
    }

    //Code yang dipanggil untuk mengurangi list karang gigi di game, dan apabila karang gigi sudah 0 atau tidak ada, maka akan trigger game complete screen
    public void RemoveKarangGigiFromList(GameObject karangGigi)
    {
        _karangGigiList.Remove(karangGigi);

        if(_karangGigiList.Count == 0)
        {
            Debug.Log("You won");
            SFXManager.GetInstance().OnKarangGigiOutro();
            StartCoroutine(OnTriggerDelayOutro(SFXManager.GetInstance()._sfxOutroKarangGigiLaluWinScreen.length));
        }
    }

    //Function yang dipanggil untuk menampilkan game panel secara delay
    IEnumerator OnTriggerDelayIntro(float audioClipDuration)
    {
        yield return new WaitForSeconds(audioClipDuration);
        _gamePanel.SetActive(true);
    }

    //Function yang dipanggil untuk menghilangkan game panel secara delay
    IEnumerator OnTriggerDelayOutro(float audioClipDuration)
    {
        yield return new WaitForSeconds(audioClipDuration);
        _onWin.Raise();
        _worldGameObject.SetActive(false);
        _gamePanel.SetActive(false);
        _winPanel.SetActive(true);
    }
}
