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
    private Image slidePanel;

    [SerializeField]
    private Image nextLevelPanel;

    [SerializeField]
    private Image StartPanel;

    [SerializeField]
    private Transform canvas;
    private Camera mainCamera;


    void Start()
    {
        mainCamera = Camera.main;
        GameManager.Instance.GameStateChanged += OnGameStateChanged;
        CloseAllPanels();
        StartPanel.gameObject.SetActive(true);

        nextLevelText.text = "Level " + (LevelController.Instance.CurrentLevel + 2).ToString();
        startLevelText.text = "Level " + (LevelController.Instance.CurrentLevel + 1).ToString();

        mainObjectLevelText.text = (LevelController.Instance.CurrentLevel + 1).ToString();

    }

    private void SlideAnimation(Action setOnComplete)
    {
        setOnComplete += ()=> slidePanel.rectTransform.position = new Vector3(-1800,0,0);
        slidePanel.gameObject.SetActive(true);
        slidePanel.rectTransform.LeanMoveX(-600,.7f);
        LeanTween.delayedCall(1f,setOnComplete);
    }

    public void NextLevelButton()
    {
        SlideAnimation(()=> 
        {
            CloseAllPanels();
            LevelController.Instance.GetNextLevel();
        });
    }

    public void OpenFailPanel()
    {
        CloseAllPanels();
        failPanel.gameObject.SetActive(true);
    }

    public void OpenNextLevelPanel()
    {
        mainObjectLevelText.text = (LevelController.Instance.CurrentLevel + 2).ToString();
        CloseAllPanels();
        
        nextLevelText.text = "Level " + (LevelController.Instance.CurrentLevel + 2).ToString();
        startLevelText.text = "Level " + (LevelController.Instance.CurrentLevel + 1).ToString();
        nextLevelPanel.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SlideAnimation(()=>
        {
            CloseAllPanels();
            GameManager.Instance.UpdateGameState(GameStates.Game);
        });
    }

    private void CloseAllPanels()
    {
        for (int i = 0; i < canvas.childCount; i++)
        {
            canvas.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void FailSlidePanelMovement()
    {
        Color color;
        ColorUtility.TryParseHtmlString("#3F0155", out color);
        mainCamera.backgroundColor = color;

        failPanel.gameObject.SetActive(true);
        failPanel.rectTransform.position = new Vector3(1300,0,0);
        LeanTween.delayedCall(1,()=>failPanel.rectTransform.LeanMoveX(0,.7f).setOnComplete(()=> OpenFailPanel()));
        //failPanel.rectTransform.LeanMoveX(0,.7f).setOnComplete(()=> OpenFailPanel());
    }
    
    private void OnGameStateChanged(GameStates newState)
    {
        switch (newState)
        {
            case GameStates.Success:
                mainCamera.backgroundColor = Color.green;
                LeanTween.delayedCall(.5f, ()=> OpenNextLevelPanel());
                
                break;

            case GameStates.Game:
                mainCamera.backgroundColor = Color.black;
                break;

            case GameStates.Fail:
                FailSlidePanelMovement();
                //OpenFailPanel();
                break;
        }
    }
}
