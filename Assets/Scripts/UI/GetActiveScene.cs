using UnityEngine;
using UnityEngine.SceneManagement;

public class GetActiveScene : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetString("ActiveScene", SceneManager.GetActiveScene().name);
        print("ActiveScene --- " + PlayerPrefs.GetString("ActiveScene"));
    }
}
