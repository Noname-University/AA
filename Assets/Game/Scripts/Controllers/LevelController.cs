using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoSingleton<LevelController>
{
    [SerializeField]
    private Level[] levels;

    private int currentLevel = 0;

    public int CurrentLevel => currentLevel;

    public int CurrentArrowCount { get; private set; }

    public float Speed { get; private set; }

    private void Awake() 
    {
        currentLevel = PlayerPrefs.GetInt("Level");
        
    }
    private void Start() 
    {
        
        GameManager.Instance.GameStateChanged += OnGameStateChanged;
    }

    public void InitLevel()
    {
        currentLevel = PlayerPrefs.GetInt("Level");
        CurrentArrowCount = levels[currentLevel].arrowCount;
        Speed = levels[currentLevel].mainObjectSpeed;
        ArrowController.Instance.RestartArrows(levels[currentLevel].arrowCount);
        
    }

    public void GetNextLevel()
    {
        PlayerPrefs.SetInt("Level",currentLevel + 1);
        GameManager.Instance.UpdateGameState(GameStates.Game);
    }

    private void OnGameStateChanged(GameStates newState)
    {
        if(newState == GameStates.Game)
        {
            InitLevel();
        }
    }

}
