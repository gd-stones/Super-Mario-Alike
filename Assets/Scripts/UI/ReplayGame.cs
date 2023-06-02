using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ReplayGame : MonoBehaviour, IPointerDownHandler
{
    private string levelToLoad;

    private void FixedUpdate()
    {
        levelToLoad = PlayerPrefs.GetString("currentSceneName");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene(levelToLoad);
    }
}