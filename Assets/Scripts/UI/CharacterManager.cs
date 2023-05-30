using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject character;

    private void Start()
    {
        character = GameObject.Find(SelectionCharacter.Instance.nameCharacter);
    }

    private void Update()
    {
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
            print("character is null");
        }
    }


    //public static string activeCharacter;
    //public static GameObject character;

    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //private void Update()
    //{
    //    character = GameObject.Find(activeCharacter);
    //    //print("------------------ " + character.name.ToString());

    //    if (character != null)
    //    {
    //        if (character.activeSelf)
    //        {
    //            print(character.activeSelf);
    //            return;
    //        }
    //        else
    //        {
    //            character.SetActive(true);
    //        }
    //    }
    //    else
    //    {
    //        print("character is null");
    //    }
    //}
}
