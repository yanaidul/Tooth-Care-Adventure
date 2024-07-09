using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSelectionManager : MonoBehaviour
{
    [SerializeField] private MoveOnStart _moveOnStart;
    [SerializeField] private Button _karangGigi;
    [SerializeField] private Button _cabutGigi;
    [SerializeField] private Doctor _doctor;
    [SerializeField] private GameObject _skipButton;
    
    public void OnClickSkipButton()
    {
        _moveOnStart.OnClickSkipButton();
        _doctor.OnClickSkipButton();
        _karangGigi.interactable = true;
        _cabutGigi.interactable = true;
        _skipButton.gameObject.SetActive(false);
    }
}
