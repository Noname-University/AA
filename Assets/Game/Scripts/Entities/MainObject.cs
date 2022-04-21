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
            transform.Rotate(0, 0, -(LevelController.Instance.Speed * Time.deltaTime));
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        var arrow = other.gameObject.GetComponent<Arrow>();
        if (arrow != null)
        {
            other.transform.parent = transform;
            if (++childObjectCount == LevelController.Instance.CurrentArrowCount && !isFail)
            {
                GameManager.Instance.UpdateGameState(GameStates.Success);
            }
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
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
                childObjectCount = 0;
                break;

        }
    }
}
