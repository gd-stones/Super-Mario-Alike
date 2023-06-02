using UnityEngine;
using UnityEngine.EventSystems;

public class MoveOnMobile : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private int direction;
    [SerializeField] private PlayerMovement playerMovement;
    private float inputOnMobile = 0;

    public void OnPointerDown(PointerEventData eventData)
    {
        inputOnMobile = inputOnMobile + Time.deltaTime * direction;
        if (inputOnMobile > direction || inputOnMobile < direction)
            inputOnMobile = direction;

        playerMovement.ChangeDirection(inputOnMobile);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerMovement.ResetDirection();
        inputOnMobile = 0;
    }
}
