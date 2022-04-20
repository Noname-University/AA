using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Text nextLevelText;

    [SerializeField]
    private Text startLevelText;

    [SerializeField]
    private Image failPanel;

    [SerializeField]
    private Image nextLevelPanel;

    [SerializeField]
    private Image StartPanel;


    void Start()
    {
        GameManager.Instance.GameStateChanged += OnGameStateChanged;

        StartPanel.gameObject.SetActive(true);

        nextLevelText.text = "Level " + (SceneManager.GetActiveScene().buildIndex + 2).ToString();
        startLevelText.text = "Level " + (SceneManager.GetActiveScene().buildIndex + 1).ToString();

    }

    public void NextLevelButton()
    {
        LevelController.Instance.GetNextLevel();
    }

    public void OpenFailPanel()
    {
        failPanel.gameObject.SetActive(true);

        nextLevelPanel.gameObject.SetActive(false);
    }

    public void OpenNextLevelPanel()
    {
        failPanel.gameObject.SetActive(false);
        nextLevelPanel.gameObject.SetActive(true);
    }

    public void Restart()
    {
        LevelController.Instance.Restart();
    }

    public void CloseStartPanel()
    {
        StartPanel.gameObject.SetActive(false);
        GameManager.Instance.UpdateGameState(GameStates.Game);
    }
    
    private void OnGameStateChanged(GameStates newState)
    {
        switch (newState)
        {
            case GameStates.Success:
            OpenNextLevelPanel();
            break;

            case GameStates.Fail:
            OpenFailPanel();
            break;
        }
    }
}
