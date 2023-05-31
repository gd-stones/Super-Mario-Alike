using UnityEngine;
using UnityEngine.EventSystems;

public class AttackOnMobile : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private PlayerAttack attackOnMobile;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        attackOnMobile.Attack();
    }
}