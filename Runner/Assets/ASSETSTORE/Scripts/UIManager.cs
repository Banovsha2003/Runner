using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private TMP_Text coinCountText;

    public static UIManager Instance { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    public void OnClickStart()
    {
        Time.timeScale = 1;
    }

    public void OpenStartPanel()
    {
        startPanel.SetActive(true);
    }

    public void CloseStartPanel()
    {
        startPanel.SetActive(false);
    }

    public void OpenGamePanel()
    {
        gamePanel.SetActive(true);
    }

    public void CloseGamePanel()
    {
        gamePanel.SetActive(false);
    }

    public void UpdateCoinValue()
    {
        coinCountText.text = StackHolder.Instance.coffeeList.Count.ToString();
    }
}