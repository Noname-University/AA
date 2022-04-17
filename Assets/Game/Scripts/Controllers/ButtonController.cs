using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Helpers;

public class ButtonController : MonoSingleton<ButtonController>
{
    [SerializeField]
    private Text levelIndex;

    private void Start()
    {
        LevelText();
    }

    public void btnClick()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void LevelText()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        levelIndex.text = "Level " + currentScene.ToString();
    }
}
