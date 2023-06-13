using UnityEngine;
using UnityEngine.EventSystems;

public class PauseButton : MonoBehaviour, IPointerDownHandler
{
    public GameObject pauseUI;

    public void OnPointerDown(PointerEventData eventData)
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }
}
