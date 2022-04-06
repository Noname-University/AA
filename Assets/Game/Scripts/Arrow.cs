using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private bool control;
    void Update()
    {
        if (Input.touchCount>0)
        {
            control = true;
        }

        if (control)
        {
            transform.position +=new Vector3(0,Time.deltaTime * speed,0);
           
        }

    }

    
}
