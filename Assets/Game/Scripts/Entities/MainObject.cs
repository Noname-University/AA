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
    [SerializeField]
    private float speed;

    [SerializeField]
    private TextMeshPro levelText;

    #endregion

    #region Variables
    private bool isFail = false;
    private int childObjectCount = 0;

    #endregion

    #region Unity Methods


    private void Start()
    {
        levelText.text = SceneManager.GetActiveScene().buildIndex.ToString();
        GameManager.Instance.GameStateChanged += OnGameStateChanged; 
    }

    void Update()
    {
        if (GameManager.Instance.GameState == GameStates.Game)
        {
            transform.Rotate(0, 0, -(speed * Time.deltaTime));
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        other.transform.parent = transform;
        if (++childObjectCount == ArrowController.Instance.ArrowIndex && !isFail)
        {
            GameManager.Instance.UpdateGameState(GameStates.Success);
        }
        other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        other.gameObject.GetComponent<MeshRenderer>().enabled = true;
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    #endregion

    private void OnGameStateChanged(GameStates newState)
    {
        if (newState == GameStates.Fail)
            isFail = true;
    }
}
