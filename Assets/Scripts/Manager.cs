using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private bool _gamePaused;
    [SerializeField] private GameObject _pauseMenu;

    void PauseGame(bool value) {

        if (value == true)
        {
            _pauseMenu.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
            _gamePaused = true;
                

        } else
        {
            _pauseMenu.SetActive(false);
            Cursor.visible = false;
            Time.timeScale = 1;
            _gamePaused  = false;
        }

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _gamePaused == false)
        {
            PauseGame(true);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && _gamePaused == true)
        {
            PauseGame(false);
        }
    }

}
