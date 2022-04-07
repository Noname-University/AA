using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField]
    private int arrowCount;

    [SerializeField]
    private GameObject arrowPrefab;
    private Arrow[] arrowArray;
    private int currentArrow = 0;

    private void Awake()
    {
        arrowArray = new Arrow[arrowCount];
        for (int i = 0; i < arrowCount; i++)
        {
            var arrow = Instantiate(arrowPrefab, new Vector3(0, -3.28f, 0), Quaternion.identity);
            arrow.SetActive(false);
            arrowArray[i] = arrow.GetComponent<Arrow>();

        }

    }

    private void Start()
    {
        GameManager.Instance.Click += OnClick;
        arrowArray[0].gameObject.SetActive(true);
    }


    private void arrowLine()
    {

    }

    public void OnClick()
    {
        arrowArray[currentArrow].ArrowFire();
        if (arrowArray[currentArrow].transform.position.y > 0.25)
        {
            arrowArray[++currentArrow].gameObject.SetActive(true);
        }

    }

}
