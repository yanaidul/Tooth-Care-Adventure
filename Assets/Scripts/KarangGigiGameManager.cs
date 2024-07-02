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
        _gamePanel.SetActive(true);
        _winPanel.SetActive(false);
    }

    //Code yang dipanggil untuk mengurangi list karang gigi di game, dan apabila karang gigi sudah 0 atau tidak ada, maka akan trigger game complete screen
    public void RemoveKarangGigiFromList(GameObject karangGigi)
    {
        _karangGigiList.Remove(karangGigi);

        if(_karangGigiList.Count == 0)
        {
            _onWin.Raise();
            Debug.Log("You won");
            _worldGameObject.SetActive(false);
            _gamePanel.SetActive(false);
            _winPanel.SetActive(true);
        }
    }
}
