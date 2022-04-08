using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

public class ArrowController : MonoSingleton<ArrowController>
{
    [SerializeField]
    private int arrowCount;

    [SerializeField]
    private GameObject arrowPrefab;
    private Arrow[] arrowArray;
    private int currentArrow = 0;
    private bool isGameCountinue = true;
    public int ArrowCount => arrowCount-(currentArrow+1);


    private void Awake()
    {
        arrowArray = new Arrow[arrowCount];
        for (int i = 0; i <arrowCount ; i++)
        {
            var arrow = Instantiate(arrowPrefab, new Vector3(0, -3.28f, 0), Quaternion.identity);
            arrow.SetActive(false);
            arrowArray[i] = arrow.GetComponent<Arrow>();
            
        }
    }

    private void Start()
    {
        
        GameManager.Instance.Fail += OnFail;
        GameManager.Instance.Click += OnClick;
        arrowArray[0].gameObject.SetActive(true);
    }


    public void OnClick()
    {
        
        if (isGameCountinue)
        {
            arrowArray[currentArrow].ArrowFire();
            if (arrowArray[currentArrow].transform.position.y > 0.25)
            {
                arrowArray[++currentArrow].gameObject.SetActive(true);
            }

        }
        
    }
    
    private void OnFail()
    {
        isGameCountinue = false;
    }
}

    
