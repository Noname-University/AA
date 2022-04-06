using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObject : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject arrow;

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
