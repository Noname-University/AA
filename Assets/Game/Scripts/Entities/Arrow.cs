using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private TextMeshPro text;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private Transform ball;

    [SerializeField]
    private Transform stick;

    public void ArrowFire()
    {
        rb.velocity = new Vector3(0, speed, 0);
    }

    public void UpdateText(string newText)
    {
        text.text = newText;
    }

    public void UpdateMesh(bool boolean)
    {
        GetComponent<MeshRenderer>().enabled = boolean;
    }

    public void GetAnim()
    {
        stick.LeanScaleY(7,.5f).setOnComplete(()=> stick.localScale = Vector3.one);
        ball.LeanMoveLocalY(-10,.5f).setOnComplete(()=> ball.localPosition = new Vector3(0,-1.7f,0));
    }
}
