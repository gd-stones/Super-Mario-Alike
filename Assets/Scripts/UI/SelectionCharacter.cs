using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionCharacter : MonoBehaviour
{
    public int characterId;

    public void ChooseCharacter()
    {
        PlayerPrefs.SetInt("characterId", characterId);
        SceneManager.LoadScene("LevelSelection");
    } 
}