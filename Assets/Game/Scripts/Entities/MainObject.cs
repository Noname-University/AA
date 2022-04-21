using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class MainObject : MonoSingleton<MainObject>
{
    #region Serializefields

    #endregion

    #region Variables
    private bool isFail = false;
    private int childObjectCount = 0;
    private float timer;

    private int direction = 1;

    #endregion

    #region Unity Methods


    private void Start()
    {
        GameManager.Instance.GameStateChanged += OnGameStateChanged;
    }

    void Update()
    {
        if (GameManager.Instance.GameState == GameStates.Game)
        {
            transform.Rotate(0, 0, (LevelController.Instance.Speed * Time.deltaTime) * direction);

            if(LevelController.Instance.Timer == 0) return;
            
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = LevelController.Instance.Timer;
                direction *= -1;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        var arrow = other.gameObject.GetComponentInChildren<Arrow>();
        if (arrow != null)
        {
            other.transform.parent = transform;
            if (++childObjectCount == LevelController.Instance.CurrentArrowCount && !isFail)
            {
                GameManager.Instance.UpdateGameState(GameStates.Success);
            }
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            arrow.UpdateMesh(true);
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }

    }

    #endregion

    private void OnGameStateChanged(GameStates newState)
    {
        switch (newState)
        {
            case GameStates.Fail:
                isFail = true;
                childObjectCount = 0;
                break;

            case GameStates.Game:
                isFail = false;
                timer = LevelController.Instance.Timer;
                childObjectCount = 0;
                break;

        }
    }
}
