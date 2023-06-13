using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CancelButton : MonoBehaviour, IPointerDownHandler
{
    private string prevScene;
    
    void Start() => prevScene = PlayerPrefs.GetString("ActiveScene");

    public void OnPointerDown(PointerEventData eventData) => SceneManager.LoadScene(prevScene);
}
