using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;

public class ObstacleController : MonoSingleton<ObstacleController>
{
    [SerializeField]
    private GameObject obstaclePrefab;

    [SerializeField]
    private int maxObstacleCount;

    private Transform[] obstacleArray;


    private void Awake()
    {
        obstacleArray = new Transform[maxObstacleCount];
        for (int i = 0; i < maxObstacleCount; i++)
        {
            var obstacle = Instantiate(obstaclePrefab, new Vector3(0, 1.85f, 0), Quaternion.identity);

            obstacle.transform.parent = MainObject.Instance.transform;
            obstacle.gameObject.SetActive(false);
            obstacleArray[i] = obstacle.transform;
        }
    }
    private void Start() 
    {
        GameManager.Instance.GameStateChanged += OnGameStateChanged;
    }

    private void GetAnimations()
    {
        for (int i = 0; i < LevelController.Instance.ObstacleDegrees.Length; i++)
        {
            obstacleArray[i].GetComponent<Obstacle>().GetAnim();
        }
    }

    public void InitObstacles()
    {
        for (int i = 0; i < LevelController.Instance.ObstacleDegrees.Length; i++)
        {
            obstacleArray[i].eulerAngles = new Vector3(0, 0, LevelController.Instance.ObstacleDegrees[i]);
            obstacleArray[i].gameObject.SetActive(true);
        }

        for (int i = LevelController.Instance.ObstacleDegrees.Length; i < maxObstacleCount; i++)
        {
            obstacleArray[i].gameObject.SetActive(false);
        }
    }

    private void OnGameStateChanged(GameStates newState)
    {
        switch (newState)
        {
            case GameStates.Success:
                GetAnimations();
                break;
        }
    }
}
