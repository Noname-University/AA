using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;


public class MainObject : MonoSingleton<MainObject>
{
    [SerializeField]
    private float speed;
    private bool isGameCountinue = true;
    public int chilObjectCount;

    private void Start()
    {
        GameManager.Instance.Fail += OnFail;
    }

    void Update()
    {
        if (isGameCountinue)
        {
            transform.Rotate(0, 0, -(speed * Time.deltaTime));
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        other.transform.parent = transform;
        chilObjectCount++;
        other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        other.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    private void OnFail()
    {
        isGameCountinue = false;
    }
}
