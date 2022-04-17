using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    

    public void ArrowFire()
    {
        rb.velocity = new Vector3(0, speed * Time.deltaTime, 0);
    }





}
