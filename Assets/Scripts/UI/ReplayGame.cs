using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ReplayGame : MonoBehaviour, IPointerDownHandler
{
    private string levelToLoad;

    public void SetLevelToLoad(string levelName)
    {
        levelToLoad = levelName;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene(levelToLoad);
    }
}