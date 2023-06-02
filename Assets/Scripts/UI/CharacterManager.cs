using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private int characterId;
    private int characterIdActive;
    public GameObject[] characters;
    private GameObject characterActive;

    private void Start()
    {
        characterIdActive = PlayerPrefs.GetInt("characterId");
    }

    private void Update()
    {
        if (characterActive != null)
        {
            return;
        }
        ActiveCharacter();
    }

    private void ActiveCharacter()
    {
        foreach (var character in characters)
        {
            characterId = character.GetComponent<SelectionCharacter>().characterId;
            if (characterId == characterIdActive)
            {
                character.SetActive(true);
                characterActive = character;
            }    
        }
    }
}
