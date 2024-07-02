using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public enum StageType
{
    Mencair,
    Menyublim,
    Membeku,
    Menguap,
    Mengkristal,
    Mengembun,
    Konduktor,
    Isolator,
    None
}

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameEventNoParam _onCollideWithCorrectObject;
    [SerializeField] private GameEventNoParam _onCollideWithIncorrectObject;
    [SerializeField] private GameEventNoParam _onCollideWithBomb;
    [SerializeField] private GameEventNoParam _onGameStart;
    [SerializeField] private GameEventNoParam _onWin;
    [SerializeField] private int _score;
    [SerializeField] private int _totalScore;
    [SerializeField] private TextMeshProUGUI _scoreText,_totalScoreText;
    [SerializeField] private List<GameObject> _spawnerList = new();
    [SerializeField] private List<GameObject> _gameOpeningPanelList = new();
    [SerializeField] private GameObject _gameRelatedObjects;
    [SerializeField] private StageType _currentStageType;

    public StageType CurrentStageType => _currentStageType;
    private void Start()
    {
        _gameRelatedObjects.SetActive(false);
        TurnOffSpawners();
        _currentStageType = StageType.Mencair;
        _totalScore = 0;
    }

    public void OnStartGame()
    {
        Time.timeScale = 1;

        _onGameStart.Raise();
        _score = 0;
        _scoreText.SetText(_score.ToString());
        _totalScoreText.SetText(_totalScore.ToString());
        _gameRelatedObjects.SetActive(true);
        _spawnerList[(int)_currentStageType].SetActive(true);
    }

    public void OnGameOver()
    {
        _gameRelatedObjects?.SetActive(false);
    }

    public void OnCollideWithCorrectObject()
    {
        _onCollideWithCorrectObject.Raise();
        _score += 10;
        _totalScore += 10;
        _scoreText.SetText(_score.ToString());
        _totalScoreText.SetText(_totalScore.ToString());

        if(_score >= 100)
        {

            if(_currentStageType == StageType.Isolator)
            {
                _onWin.Raise();
                _gameRelatedObjects?.SetActive(false);
            }
            else
            {
                OnProceedNextStage();
            }

        }
    }

    public void OnCollideWithIncorrectObject()
    {
        _onCollideWithIncorrectObject.Raise();
        if (_score > 0)
        {
            _score -= 5;
            _scoreText.SetText(_score.ToString());
        }

        if(_totalScore > 0)
        {
            _totalScore -= 5;
            _totalScoreText.SetText(_totalScore.ToString());
        }
        
    }

    public void OnCollideWithBomb()
    {
        _onCollideWithBomb.Raise();

    }

    private void OnProceedNextStage()
    {
        Time.timeScale = 0;
        _currentStageType++;
        TurnOffSpawners();
        _gameRelatedObjects.gameObject.SetActive(false);
        _gameOpeningPanelList[(int)_currentStageType].SetActive(true);
    }

    private void TurnOffSpawners()
    {
        foreach (GameObject spawner in _spawnerList)
        {
            spawner.gameObject.SetActive(false);
        }
    }
}
