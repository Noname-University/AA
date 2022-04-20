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

    private bool isAnim = false;

    private Arrow[] arrowArray;
    private int currentArrow = 0;


    public int ArrowIndex => arrowCount;/////



    private void Awake()
    {
        arrowArray = new Arrow[arrowCount];

        for (int i = 0; i < arrowCount; i++)
        {
            var arrow = Instantiate(arrowPrefab, new Vector3(0, -1.47f + (i * -1.50f), 0), Quaternion.identity);
            arrowArray[i] = arrow.GetComponent<Arrow>();
            arrowArray[i].gameObject.SetActive(true);

            arrowArray[i].GetComponent<MeshRenderer>().enabled = false;
            arrowArray[i].transform.GetChild(0).GetChild(0).GetComponent<TextMeshPro>().text = (arrowCount - i).ToString();//////
        }
    }

    private void Start()
    {
        GameManager.Instance.Click += OnClick;
    }

    public void OnClick()
    {
        if (GameManager.Instance.GameState == GameStates.Game && !isAnim)
        {
            if (currentArrow < arrowCount)
            {
                isAnim = true;
                LeanTween.delayedCall(.2f,()=>isAnim = false);
                arrowArray[currentArrow++].ArrowFire();

                for (int i = currentArrow; i < arrowArray.Length; i++)
                {
                    arrowArray[i].transform.LeanMoveY(arrowArray[i].transform.position.y + 1.50f, .2f);
                }
            }
        }
    }
}


