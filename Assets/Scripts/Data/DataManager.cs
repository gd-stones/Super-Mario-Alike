using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    public int coin;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    [System.Serializable] //Cho phep du lieu duoc chuyen doi thanh dang json
    class SaveData
    {
        public int coin;
    }

    public void WriteData()
    {
        SaveData data = new SaveData();
        data.coin = coin;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/coinmanager.json", json);
        //Debug.Log("Application.persistentDataPath --- " + Application.persistentDataPath);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/coinmanager.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            coin = data.coin;
        }
    }
}