using UnityEngine;
using UnityEngine.EventSystems;

public class MoveOnMobile : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private int direction;
    [SerializeField] private PlayerMovement playerMovement;
    float jumpAtTime = -1;

    public void OnPointerDown(PointerEventData eventData)
    {
        playerMovement.ChangeDirection(direction);
        //jumpAtTime = Time.time;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerMovement.ResetDirection();
        //jumpAtTime = -1;
    }

    //void Update()
    //{
    //    if(jumpAtTime > -1)
    //    {
    //        var duration = Time.time - jumpAtTime;

    //    }
    //}
}
