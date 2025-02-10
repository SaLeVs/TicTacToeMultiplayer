using System;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject crossArrowGameObject;
    [SerializeField] private GameObject circleArrowGameObject;
    [SerializeField] private GameObject CrossYouTextGameObject;
    [SerializeField] private GameObject CircleYouTextGameObject;


    private void Awake()
    {
        crossArrowGameObject.SetActive(false);
        circleArrowGameObject.SetActive(false);
        CrossYouTextGameObject.SetActive(false);
        CircleYouTextGameObject.SetActive(false);

    }

    private void Start()
    {
        GameManager.Instance.OnGameStarted += GameManager_OnGameStarted;
        GameManager.Instance.OnCurrentPlayablePlayerTypeChanged += GameManager_OnCurrentPlayablePlayerTypeChanged;
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
