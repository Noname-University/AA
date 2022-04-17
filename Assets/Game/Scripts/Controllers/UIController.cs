using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Image inGamePanel;

    [SerializeField]
    private Image deadPanel;

    [SerializeField]
    private Image nextLevelPanel;

    [SerializeField]
    private Text ArrowIndex;

    void Start()
    {
        OpenInGamePanel();
        GameManager.Instance.Fail += OnFail;
        GameManager.Instance.Succes += OnSuccess;
    }
    private void Update()
    {
        ArrowCount();
    }
    public void OnFail()
    {
        OpenDeadPanel();
    }

    public void OnSuccess()
    {
        OpenNextLevelPanel();     
    }

    public void OpenInGamePanel()
    {
        deadPanel.gameObject.SetActive(false);
        inGamePanel.gameObject.SetActive(true);
        nextLevelPanel.gameObject.SetActive(false);
    }
    public void OpenDeadPanel()
    {
        deadPanel.gameObject.SetActive(true);
        inGamePanel.gameObject.SetActive(false);
        nextLevelPanel.gameObject.SetActive(false);
    }
    public void OpenNextLevelPanel()
    {
        deadPanel.gameObject.SetActive(false);
        inGamePanel.gameObject.SetActive(false);
        nextLevelPanel.gameObject.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ArrowCount()
    {
        ArrowIndex.text = ArrowController.Instance.ArrowCount.ToString();
    }

}
