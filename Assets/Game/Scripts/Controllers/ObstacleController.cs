using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    private GameObject obstaclePrefab;

    private Arrow[] obstacleArray;


    private void Awake()
    {
        obstacleArray = new Arrow[LevelController.Instance.Obstacle.Length];
        for (int i = 0; i < LevelController.Instance.Obstacle.Length; i++)
        {
            var obstacle = Instantiate(obstaclePrefab, new Vector3(0, 1.85f, 0), Quaternion.identity);

            obstacleArray[i].transform.parent = MainObject.Instance.transform;
            obstacleArray[i] = obstacle.GetComponent<Arrow>();

        }
    }


    public void RestartObstacle(int obstacleCount)
    {




    }
}
