using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private Button _startNewGame;
    [SerializeField] private Button _exit;
    void Start()
    {
        _startNewGame.onClick.AddListener(StartNewGame);
        _exit.onClick.AddListener(Exit);
    }

    private void OnDestroy()
    {
        _startNewGame.onClick.RemoveAllListeners();
        _exit.onClick.RemoveAllListeners();
    }
    private void StartNewGame() {

        SceneManager.LoadScene("StartLevel");
    }

    private void Exit()
    {
        Application.Quit();
    }

}
