using UnityEngine;
using UnityEngine.EventSystems;

public class GridPosition : MonoBehaviour
{

    [SerializeField] private int x;
    [SerializeField] private int y;

    private void OnMouseDown()
    {
        Debug.Log("Click! " + x + ", " + y);
        GameManager.Instance.ClickedOnGridPosition(x, y); // here we acess the GameManager instance and call the ClickedOnGridPosition method
    }
}

