using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons;

    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelAt)
            {
                levelButtons[i].interactable = false;
                levelButtons[i].GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f, 1f);
            }
        }
    }
}
