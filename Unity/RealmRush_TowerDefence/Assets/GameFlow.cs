using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameFlow : MonoBehaviour
{
    public static GameFlow Instance;
    public bool inputActive = true, paused = false;

    void Awake()
    {
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            //DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    void Update()
    {
        ManageInput();
    }

    private void ManageInput()
    {
        if (inputActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (paused)
                {
                    StartGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        paused = true;
        UI_Manager.Instance.ToggleMenu(true);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        paused = false;
        UI_Manager.Instance.ToggleMenu(false);
    }

    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
