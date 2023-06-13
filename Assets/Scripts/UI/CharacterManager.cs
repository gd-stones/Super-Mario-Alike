using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] characters;
    internal GameObject characterActive;

    private void Awake()
    {
        ActiveCharacter();
    }

    private void ActiveCharacter()
    {
        int characterIdActive = PlayerPrefs.GetInt("characterId", 1);

        foreach (var character in characters)
        {
            int characterId = character.GetComponent<SelectionCharacter>().characterId;
            if (characterId == characterIdActive)
            {
                character.SetActive(true);
                characterActive = character;
            }
        }
    }
}
