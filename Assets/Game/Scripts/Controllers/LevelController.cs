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

    private void Start() 
    {
        currentLevel = PlayerPrefs.GetInt("Level");
    }
    public void GetNextLevel()
    {
        PlayerPrefs.SetInt("Level",currentLevel + 1);
    }

    public void Restart()
    {
        
    }

}
