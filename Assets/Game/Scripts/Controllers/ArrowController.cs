using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField]
    private int arrowCount;

    [SerializeField]
    private GameObject arrowPrefab;

    private GameObject[] arrowArray;

    private void Awake()
    {
        arrowArray = new GameObject[arrowCount];
        for (int i = 0; i < arrowCount; i++)
        {
            var arrow = Instantiate(arrowPrefab, new Vector3(0, -3.28f, 0), Quaternion.identity);

            arrow.SetActive(false);
            arrowArray[i] = arrow;

        }



    }
    private void Update()
    {
        arrowLine();
    }


    private void arrowLine()
    {
        arrowArray[0].SetActive(true);

        for (int i = 0; i < arrowCount - 1; i++)
        {


            if (arrowArray[i].transform.position.y > 0.5)
            {
                arrowArray[i + 1].SetActive(true);

            }

        }

    }

}
