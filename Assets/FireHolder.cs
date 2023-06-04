using DG.Tweening;
using TMPro;
using UnityEngine;

public class FireHolder : MonoBehaviour
{
    public static FireHolder Instance;  

    public TextMeshProUGUI remainfireTxt;
    public int remainFire;

    [HideInInspector] public bool isWinGame, isloseGame;

    public CanvasGroup winGamePanel;

    private void Start()
    {
        Instance = this;

        isWinGame = false;
        isloseGame = false;
        winGamePanel.alpha = 0f;

        remainFire = transform.childCount;
    }

    public void DecreaseActvFire()
    {
        remainFire--;
        remainfireTxt.text = "Remain Fire : " + remainFire.ToString();

        if (remainFire <= 0 && !isloseGame)
        {
            winGamePanel.DOFade(1, 0.5f);
            isWinGame = true;
        }
    }

}
