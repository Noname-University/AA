using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private bool control;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {


        if (Input.touchCount > 0)
        {

            control = true;
        }

        if (control)
        {
            rb.velocity = new Vector3(0, speed * Time.deltaTime, 0);
            // transform.position +=new Vector3(0,Time.deltaTime * speed,0);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        var enemyT = other.GetComponent<Arrow>();
        if (enemyT != null)
        {
            Time.timeScale = 0;
        }
    }




}
