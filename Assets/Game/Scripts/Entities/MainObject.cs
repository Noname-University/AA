using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;


public class MainObject : MonoSingleton<MainObject>
{
    [SerializeField]
    private float speed;

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        transform.Rotate(0, 0, -(speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {

        other.transform.parent = transform;
        other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
    }
}
