using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _manager;

    private void Start()
    {
        _continueButton.onClick.AddListener(Continue);
        _exitButton.onClick.AddListener(Exit);
    }

    private void OnDestroy()
    {
        _continueButton.onClick.RemoveAllListeners();
        _exitButton.onClick.RemoveAllListeners();
    }

    void Continue() {

    }

    void Exit() {

        Application.Quit();

    }


}
