using UnityEngine;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{
    public Text My_text;

    public void Down()
    {
        My_text.text = "Jump down";
    }

    public void Up()
    {
        My_text.text = "Jump up";
    }
}
