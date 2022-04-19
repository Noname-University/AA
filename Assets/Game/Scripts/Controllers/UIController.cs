using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{


    [SerializeField]
    private Image deadPanel;

    [SerializeField]
    private Image nextLevelPanel;


    void Start()
    {
        GameManager.Instance.Fail += OnFail;
        GameManager.Instance.Succes += OnSuccess;
    }

    public void OnFail()
    {
        OpenDeadPanel();
    }

    public void OnSuccess()
    {
        OpenNextLevelPanel();
    }


    public void OpenDeadPanel()
    {
        deadPanel.gameObject.SetActive(true);

        nextLevelPanel.gameObject.SetActive(false);
    }
    public void OpenNextLevelPanel()
    {
        deadPanel.gameObject.SetActive(false);
        nextLevelPanel.gameObject.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
