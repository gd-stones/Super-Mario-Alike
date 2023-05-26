using UnityEngine;
using UnityEngine.EventSystems;

public class JumpOnMobile : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool jump = false;
    [SerializeField] private PlayerMovement playerMovement;

    void FixedUpdate()
    {
        if (jump && playerMovement.CanJump())
        {
            playerMovement.Jump();
            jump = false;
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        jump = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        jump = false;
    }
}
