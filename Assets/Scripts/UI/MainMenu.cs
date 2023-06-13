using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData) => SceneManager.LoadScene("Main");
}
