using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private bool isTouch=false;
    public event Action Fail;
    public event Action Click;

    public void StopGame(){
        Fail?.Invoke();
    }

    private void Update() {
        if (Input.touchCount > 0 && !isTouch)
        {
            isTouch=true;
            Click?.Invoke();
        }
        else
        {
            isTouch=false;
        }
    }
}
