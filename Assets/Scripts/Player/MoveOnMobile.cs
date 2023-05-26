using UnityEngine;
using UnityEngine.EventSystems;

public class MoveOnMobile : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private int direction;
    [SerializeField] private PlayerMovement playerMovement;

    public void OnPointerDown(PointerEventData eventData)
    {
        playerMovement.ChangeDirection(direction);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerMovement.ResetDirection();
    }
}
