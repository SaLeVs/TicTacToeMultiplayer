using System;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultTextMesh;
    [SerializeField] private Color winColor;
    [SerializeField] private Color loseColor;


    private void Start()
    {
        GameManager.Instance.OnGameWin += GameManager_OnGameWin;
        Hide();
    }

    private void GameManager_OnGameWin(object sender, GameManager.OnGameWinEventArgs e)
    {
        if(e.winPlayerType == GameManager.Instance.GetLocalPlayerType())
        {
            resultTextMesh.color = winColor;
            resultTextMesh.text = "YOU WIN!";
        }
        else
        {
            resultTextMesh.color = loseColor;
            resultTextMesh.text = "YOU LOSE!";
        }
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
