using DG.Tweening;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public CanvasGroup panel;
    public CanvasGroup creditPanel;
    public CanvasGroup gamePanel;

    bool crPaneloOpen = false;
    float timer;

    [Header("Texts")]
    public TextMeshProUGUI remainTxt;
    public float remainTime;

    [Header("Panel")]
    public CanvasGroup loseGamePanel;
    public CanvasGroup startPanel;

    bool isGameStart;


    private void Start()
    {
        isGameStart = false;

        creditPanel.alpha = 0.0f;
        panel.alpha = 1.0f;
        loseGamePanel.alpha = 0.0f;
        gamePanel.alpha = 0.0f;
        startPanel.alpha = 0.0f;

        panel.GetComponent<RectTransform>().DOScale(1, 0);
    }
    private void Update()
    {
        if (isGameStart && remainTime > 0 && timer < 0)
        {
            timer = 1;
            remainTime--;
            remainTxt.text = "Remain Time : " + remainTime.ToString() + " s";

            if (remainTime <= 0 && !FireHolder.Instance.isWinGame)
            {
                FireHolder.Instance.isloseGame = true;
                loseGamePanel.DOFade(1, 0.5f);
            }
        }
        else
            timer -=Time.deltaTime;
    }
    public void PlayBtn()
    {
        panel.DOFade(0, 0.5f);
        panel.GetComponent<RectTransform>().DOScale(0, 0).SetDelay(1);

        gamePanel.DOFade(1, 1f);
        startPanel.DOFade(1, 0.3f);
    }
    public void CloseStartMenu()
    {
        isGameStart = true;
        startPanel.DOFade(0, 0.3f);
    }
    public void CreditsBtn()
    {
        if (!crPaneloOpen)
        {
            creditPanel.DOKill();
            crPaneloOpen = true;
            creditPanel.DOFade(1, 0.3f);
        }
        else
        {
            creditPanel.DOKill();
            crPaneloOpen = false;
            creditPanel.DOFade(0, 0.3f);
        }
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
}
