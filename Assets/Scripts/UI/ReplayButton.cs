using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
