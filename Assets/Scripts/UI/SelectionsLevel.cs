using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionsLevel : MonoBehaviour
{
    public int level;

    void Start()
    {
    }

    public void OpenScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level " + level.ToString());
    }
}
