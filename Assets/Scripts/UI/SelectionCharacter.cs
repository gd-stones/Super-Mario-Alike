using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SelectionCharacter : MonoBehaviour
{
    public string nameCharacter;

    void Start()
    {

    }

    //public void ActiveCharacter()
    //{
    //    CharacterManager.activeCharacter = nameCharacter;
    //    SceneManager.LoadScene("MainMenu");

    //    print(CharacterManager.activeCharacter);
    //}

    public static SelectionCharacter Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        //LoadCharacter();
    }

    [System.Serializable]
    class SaveData
    {
        //Variables that need to be stored
        public string nameCharacter;
    }

    public void WriteCharacter()
    {
        SaveData data = new SaveData();
        data.nameCharacter = nameCharacter;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/charactermanager.json", json);
        
        print(Application.persistentDataPath);
       
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadCharacter()
    {
        string path = Application.persistentDataPath + "/charactermanager.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            nameCharacter = data.nameCharacter;
        }
    }
}