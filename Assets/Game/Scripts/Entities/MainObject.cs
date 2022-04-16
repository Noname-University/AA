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

    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform;
        chilObjectCount++;
        other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        other.GetComponent<MeshRenderer>().enabled = true;
    }

    private void OnFail()
    {
        isGameCountinue = false;
    }
}
