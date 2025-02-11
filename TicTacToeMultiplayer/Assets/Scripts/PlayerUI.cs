using System;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject crossArrowGameObject;
    [SerializeField] private GameObject circleArrowGameObject;
    [SerializeField] private GameObject CrossYouTextGameObject;
    [SerializeField] private GameObject CircleYouTextGameObject;
    [SerializeField] private TextMeshProUGUI playerCrossScoreText;
    [SerializeField] private TextMeshProUGUI playerCircleScoreText;


    private void Awake()
    {
        crossArrowGameObject.SetActive(false);
        circleArrowGameObject.SetActive(false);
        CrossYouTextGameObject.SetActive(false);
        CircleYouTextGameObject.SetActive(false);
        playerCrossScoreText.text = "";
        playerCircleScoreText.text = "";

    }

    private void Start()
    {
        GameManager.Instance.OnGameStarted += GameManager_OnGameStarted;
        GameManager.Instance.OnCurrentPlayablePlayerTypeChanged += GameManager_OnCurrentPlayablePlayerTypeChanged;
        GameManager.Instance.OnScoreChanged += GameManager_OnScoreChanged;
    }

    private void GameManager_OnScoreChanged(object sender, EventArgs e)
    {
        GameManager.Instance.GetScores(out int playerCrossScore, out int playerCircleScore);
        playerCrossScoreText.text = playerCrossScore.ToString();
        playerCircleScoreText.text = playerCircleScore.ToString();
    }

    private void GameManager_OnGameStarted(object sender, EventArgs e)
    {
        if(GameManager.Instance.GetLocalPlayerType() == GameManager.PlayerType.Cross)
        {
            CrossYouTextGameObject.SetActive(true);
        }
        else
        {
            CircleYouTextGameObject.SetActive(true);
        }
        playerCrossScoreText.text = "0";
        playerCircleScoreText.text = "0";

        UpdtateCurrentArrow();
    }

    private void GameManager_OnCurrentPlayablePlayerTypeChanged(object sender, EventArgs e)
    {
        UpdtateCurrentArrow();
    }


    private void UpdtateCurrentArrow()
    {
        if(GameManager.Instance.GetCurrentPlayablePlayerType() == GameManager.PlayerType.Cross)
        {
            crossArrowGameObject.SetActive(true);
            circleArrowGameObject.SetActive(false);
        }
        else
        {
            crossArrowGameObject.SetActive(false);
            circleArrowGameObject.SetActive(true);
        }
    }
}
