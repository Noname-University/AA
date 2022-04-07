using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;


public class MainObject : MonoSingleton<MainObject>
{
    [SerializeField]
    private float speed;
    private bool isGameCountinue=true;

    private void Start() {
        GameManager.Instance.Fail += OnFail;
    }

    void Update()
    {
        if (isGameCountinue)
        {
            transform.Rotate(0, 0, -(speed * Time.deltaTime));
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        other.transform.parent = transform;
        other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
    }
    
    private void OnFail(){
        isGameCountinue = false;
    }
}
