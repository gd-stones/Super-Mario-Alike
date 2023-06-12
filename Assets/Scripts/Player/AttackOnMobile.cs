using UnityEngine;
using UnityEngine.EventSystems;

public class AttackOnMobile : MonoBehaviour, IPointerDownHandler
{
    public GameObject characterManager;
    private PlayerAttack attackOnMobile;

    private void Start()
    {
        attackOnMobile = characterManager.GetComponent<CharacterManager>().characterActive.GetComponent<PlayerAttack>();
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        attackOnMobile.Attack();
    }
}