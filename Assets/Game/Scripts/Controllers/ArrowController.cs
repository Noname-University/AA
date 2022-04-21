using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;
using TMPro;


public class ArrowController : MonoSingleton<ArrowController>
{
    [SerializeField]
    private int maxArrowCount;

    [SerializeField]
    private GameObject arrowPrefab;

    private bool isAnim = false;

    private GameObject[] arrowArray;
    private int currentArrow = 0;

    private int currentArrowCount;


    public int ArrowIndex => maxArrowCount;/////



    private void Awake()
    {
        arrowArray = new GameObject[maxArrowCount];

        for (int i = 0; i < maxArrowCount; i++)
        {
            var arrow = Instantiate(arrowPrefab, new Vector3(0, -1.47f + (i * -1.50f), 0), Quaternion.identity);
            arrowArray[i] = arrow;//arrow.GetComponentInChildren<Arrow>();
        }
    }

    private void Start() 
    {
        GameManager.Instance.GameStateChanged += OnGameStateChanged;
        GameManager.Instance.Click += OnClick;
    }

    public void InitArrows(int arrowCount)
    {
        currentArrowCount = arrowCount;
        for (int i = 0; i < arrowCount; i++)
        {
            arrowArray[i].transform.parent = null;
            arrowArray[i].transform.rotation = Quaternion.identity;
            arrowArray[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            arrowArray[i].GetComponent<Rigidbody>().isKinematic = false;

            arrowArray[i].transform.position = new Vector3(0, -1.47f + (i * -1.50f), 0);
            arrowArray[i].SetActive(true);
            arrowArray[i].GetComponentInChildren<Arrow>().UpdateMesh(false);
            arrowArray[i].GetComponentInChildren<Arrow>().UpdateText((arrowCount - i).ToString());
        }

        for (int i = arrowCount; i < maxArrowCount; i++)
        {
            arrowArray[i].SetActive(false);
            arrowArray[i].GetComponentInChildren<Arrow>().UpdateMesh(false);
        }

        currentArrow = 0;
    }

    private void GetAnimations()
    {
        for (int i = 0; i < currentArrowCount; i++)
        {
            arrowArray[i].GetComponentInChildren<Arrow>().GetAnim();
        }
    }

    private void OnClick()
    {
        if (GameManager.Instance.GameState == GameStates.Game && !isAnim)
        {
            if (currentArrow < maxArrowCount)
            {
                isAnim = true;
                LeanTween.delayedCall(.2f, () => isAnim = false);
                arrowArray[currentArrow++].GetComponentInChildren<Arrow>().ArrowFire();

                for (int i = currentArrow; i < arrowArray.Length; i++)
                {
                    arrowArray[i].transform.LeanMoveY(arrowArray[i].transform.position.y + 1.50f, .2f);
                }
            }
        }
    }

    private void OnGameStateChanged(GameStates newState)
    {
        switch (newState)
        {
            case GameStates.Success:
                GetAnimations();
                break;
        }
    }
}


