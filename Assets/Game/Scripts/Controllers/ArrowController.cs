using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;
using TMPro;


public class ArrowController : MonoSingleton<ArrowController>
{
    [SerializeField]
    private int arrowCount;

    [SerializeField]
    private GameObject arrowPrefab;



    private Arrow[] arrowArray;
    private int currentArrow = 0;
    private bool isGameCountinue = true;
    public int ArrowIndex => arrowCount;



    private void Awake()
    {
        arrowArray = new Arrow[arrowCount];
        for (int i = 0; i < arrowCount; i++)
        {
            var arrow = Instantiate(arrowPrefab, new Vector3(0, -1.47f, 0), Quaternion.identity);
            arrow.SetActive(false);
            arrowArray[i] = arrow.GetComponent<Arrow>();
        }
        for (int i = 1; i < arrowCount; i++)
        {
            arrowArray[i].transform.position = new Vector3(arrowArray[i - 1].transform.position.x,
            arrowArray[i - 1].transform.position.y - 1.50f,
            arrowArray[i - 1].transform.position.z);
            arrowArray[i].gameObject.SetActive(true);
            arrowArray[i].GetComponent<MeshRenderer>().enabled = false;
            arrowArray[i].transform.GetChild(0).GetChild(0).GetComponent<TextMeshPro>().text = (arrowCount - i).ToString();
        }
    }

    private void Start()
    {
        GameManager.Instance.Fail += OnFail;
        GameManager.Instance.Click += OnClick;
        arrowArray[0].gameObject.SetActive(true);
        arrowArray[0].GetComponent<MeshRenderer>().enabled = false;
        arrowArray[0].transform.GetChild(0).GetChild(0).GetComponent<TextMeshPro>().text = (arrowCount).ToString();

    }

    public void OnClick()
    {
        if (isGameCountinue)
        {
            arrowArray[currentArrow].ArrowFire();




            if (arrowArray[currentArrow].transform.position.y > -0.6 && arrowArray[currentArrow] != arrowArray[arrowArray.Length - 1])
            {
                arrowArray[currentArrow].ArrowFire();
                currentArrow++;
                for (int i = currentArrow; i < arrowArray.Length; i++)
                {
                    arrowArray[i].transform.position = new Vector3(arrowArray[i].transform.position.x,
                     arrowArray[i].transform.position.y + 1.50f,
                     arrowArray[i].transform.position.z);

                }



            }

        }
    }



    private void OnFail()
    {
        isGameCountinue = false;

    }
}


