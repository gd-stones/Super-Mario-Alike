using UnityEngine;
using UnityEngine.EventSystems;

public class JumpOnMobile : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // ------------------------------------------------------- Workaround 2 ---------------------------------------------------
    [SerializeField] private PlayerMovement playerMovement;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        playerMovement.Jump();
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if (playerMovement.body.velocity.y > 0)
            playerMovement.body.velocity = new Vector2(playerMovement.body.velocity.x, playerMovement.body.velocity.y / 3);
    }

    // ------------------------------------------------------- Workaround 1 ---------------------------------------------------
    //private bool isJumping = false;
    //private float jumpTime = 0f;
    //private float maxJumpTime = 0.5f;
    //private float jumpPower = 14.5f;
    //[SerializeField] private PlayerMovement playerMovement;

    //void Update()
    //{
    //    if (isJumping)
    //    {
    //        jumpTime += Time.deltaTime;
    //        playerMovement.JumpOnMobile(jumpPower, jumpTime, maxJumpTime);

    //        if (jumpTime > maxJumpTime)
    //            isJumping = false;
    //    }
    //}

    //public void OnPointerDown(PointerEventData pointerEventData)
    //{
    //isJumping = true;
    //}

    //public void OnPointerUp(PointerEventData pointerEventData)
    //{
    //isJumping = false;
    //jumpTime = 0f;
    //}
}
