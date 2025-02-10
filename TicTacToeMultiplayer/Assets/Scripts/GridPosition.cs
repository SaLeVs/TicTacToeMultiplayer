using UnityEngine;
using UnityEngine.EventSystems;

public class GridPosition : MonoBehaviour
{

    [SerializeField] private int x;
    [SerializeField] private int y;

    private void OnMouseDown()
    {
        GameManager.Instance.ClickedOnGridPositionRpc(x, y, GameManager.Instance.GetLocalPlayerType()); // here we acess the GameManager instance and call the ClickedOnGridPosition method
    }
}

