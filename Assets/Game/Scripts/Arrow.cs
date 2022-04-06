using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private bool control;
    private float movement;
    private Rigidbody rb;

    private void Start() {
        rb=GetComponent<Rigidbody>();
    }
    void Update()
    {
       
        
        if (Input.touchCount>0)
        {
            Debug.Log("asdasd");
            control = true;
        }

        if (control)
        {
            rb.velocity =  new Vector3(0,speed*Time.deltaTime,0);
            // transform.position +=new Vector3(0,Time.deltaTime * speed,0);
        }

    }

    
    
}
