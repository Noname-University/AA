using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var enemyT = other.GetComponent<Ball>();
        if (enemyT == null) return;
        
        GameManager.Instance.UpdateGameState(GameStates.Fail);
        
    }
}
