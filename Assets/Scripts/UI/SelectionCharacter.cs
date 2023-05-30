using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionCharacter : MonoBehaviour
{
    public string nameCharacter;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void ActiveCharacter()
    {
        CharacterManager.activeCharacter = nameCharacter;
        SceneManager.LoadScene("MainMenu");

        print(CharacterManager.activeCharacter);
    }
}