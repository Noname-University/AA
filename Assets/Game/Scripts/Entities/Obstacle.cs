using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private Transform ball;

    [SerializeField]
    private Transform stick;

    public void GetAnim()
    {
        stick.LeanScaleY(7,.5f).setOnComplete(()=> stick.localScale = Vector3.one);
        ball.LeanMoveLocalY(-10,.5f).setOnComplete(()=> ball.localPosition = new Vector3(0,-3.2f,0));
    }
}
