using UnityEngine;
using UnityEngine.UI;

public class MoveLeft : MonoBehaviour
{
    public Text My_text;

    public void Down()
    {
        My_text.text = "Move left down";
    }

    public void Up()
    {
        My_text.text = "Move left up";
    }
}
