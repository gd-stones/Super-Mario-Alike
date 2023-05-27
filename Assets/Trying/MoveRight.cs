using UnityEngine;
using UnityEngine.UI;

public class MoveRight : MonoBehaviour
{
    public Text My_text;

    public void Down()
    {
        My_text.text = "Move right down";
    }

    public void Up()
    {
        My_text.text = "Move right up";
    }
}
