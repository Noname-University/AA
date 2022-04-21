using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro mainObjectLevelText;

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

    [SerializeField]
    private Transform canvas;


    void Start()
    {
        GameManager.Instance.GameStateChanged += OnGameStateChanged;

        StartPanel.gameObject.SetActive(true);

        nextLevelText.text = "Level " + (LevelController.Instance.CurrentLevel + 2).ToString();
        startLevelText.text = "Level " + (LevelController.Instance.CurrentLevel + 1).ToString();

        mainObjectLevelText.text = (LevelController.Instance.CurrentLevel + 1).ToString();

    }

    public void NextLevelButton()
    {
        LevelController.Instance.GetNextLevel();
        CloseAllPanels();
    }

    public void OpenFailPanel()
    {
        CloseAllPanels();
        failPanel.gameObject.SetActive(true);

    }

    public void OpenNextLevelPanel()
    {
        CloseAllPanels();
        nextLevelText.text = "Level " + (LevelController.Instance.CurrentLevel + 2).ToString();
        startLevelText.text = "Level " + (LevelController.Instance.CurrentLevel + 1).ToString();
        nextLevelPanel.gameObject.SetActive(true);
    }

    public void Restart()
    {
        CloseAllPanels();
        GameManager.Instance.UpdateGameState(GameStates.Game);
    }

    public void CloseStartPanel()
    {
        CloseAllPanels();
        GameManager.Instance.UpdateGameState(GameStates.Game);
    }

    private void CloseAllPanels()
    {
        for (int i = 0; i < canvas.childCount; i++)
        {
            canvas.GetChild(i).gameObject.SetActive(false);
        }
    }
    
    private void OnGameStateChanged(GameStates newState)
    {
        switch (newState)
        {
            case GameStates.Success:
                OpenNextLevelPanel();
                mainObjectLevelText.text = (LevelController.Instance.CurrentLevel + 2).ToString();
                break;

            case GameStates.Game:
                break;

            case GameStates.Fail:
                OpenFailPanel();
                break;
        }
    }
}
