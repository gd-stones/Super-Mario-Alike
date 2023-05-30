using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static string activeCharacter;
    public static GameObject character;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        character = GameObject.Find(activeCharacter);
        //print("------------------ " + character.name.ToString());

        if (character != null)
        {
            if (character.activeSelf)
            {
                print(character.activeSelf);
                return;
            }
            else
            {
                character.SetActive(true);
            }
        }
        else
        {
            print("sfsdfvsdfsdf");
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
