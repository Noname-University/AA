using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public event Action<GameStates> GameStateChanged;

    public GameStates GameState => gameState;

    private GameStates gameState = GameStates.Game;

    private bool isTouch = false;
    
    public event Action Click;

    private void Start() 
    {
        UpdateGameState(GameStates.Start);    
    }

    private void Update()
    {
        if (Input.touchCount > 0 && !isTouch && GameState == GameStates.Game)
        {
            isTouch = true;
            Click?.Invoke();
        }
        else
        {
            isTouch = false;
        }
    }

    public void UpdateGameState(GameStates newState)
    {
        gameState = newState;

        GameStateChanged?.Invoke(newState);
    }
}
