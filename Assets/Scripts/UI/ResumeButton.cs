using UnityEngine;
using UnityEngine.EventSystems;

public class ResumeButton : MonoBehaviour, IPointerDownHandler
{
    public GameObject pauseUI;

    public void OnPointerDown(PointerEventData eventData)
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
