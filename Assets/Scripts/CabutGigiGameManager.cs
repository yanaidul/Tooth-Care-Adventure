using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabutGigiGameManager : Singleton<CabutGigiGameManager>
{
    [SerializeField] private List<GameObject> _tahapList = new();
    [SerializeField] private List<GameObject> _uiTahapList = new();
    [SerializeField] private GameObject _worldGameObject;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameEventNoParam _onWin;
    [SerializeField] private GameObject _gamePanel;
    private int _currentTahap;

    private void Start()
    {
        _currentTahap = 0;
        OnActiveStepPanel(_currentTahap);
    }

    public void OnNextTahap()
    {
        _currentTahap++;
        OnActiveStepPanel(_currentTahap);
    }

    private void OnActiveStepPanel(int currentTahap)
    {
        Debug.Log("Next Tahap dengan current tahap= " + currentTahap);
        if(currentTahap >= 5)
        {
            _onWin.Raise();
            Debug.Log("You won");
            _worldGameObject.SetActive(false);
            _gamePanel.SetActive(false);
            _winPanel.SetActive(true);
        }
        else
        {
            for (int i = 0; i < _tahapList.Count; i++)
            {
                if (i == currentTahap)
                {
                    _tahapList[i].SetActive(true);
                    _uiTahapList[i].SetActive(true);
                    continue;
                }
                _tahapList[i].SetActive(false);
                _uiTahapList[i].SetActive(false);
            }
        }

    }
}
