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
    private Text ArrowIndex;

    // Start is called before the first frame update
    void Start()
    {
        OpenInGamePanel();

        GameManager.Instance.Fail += OnFail;
    }
    private void Update()
    {
        ArrowCount();
    }
    public void OnFail()
    {
        OpenDeadPanel();
    }

    public void OpenInGamePanel()
    {
        deadPanel.gameObject.SetActive(false);
        inGamePanel.gameObject.SetActive(true);
    }
    public void OpenDeadPanel()
    {
        deadPanel.gameObject.SetActive(true);
        inGamePanel.gameObject.SetActive(false);
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
