using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayLevel : MonoBehaviour
{
    public Text levelDisplay;

    private void Start() => levelDisplay.text = SceneManager.GetActiveScene().buildIndex.ToString();
}
