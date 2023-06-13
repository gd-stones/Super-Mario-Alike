using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public Text levelDisplay;
    private int seconds = 300;

    private void Start()
    {
        StartCoroutine(Countdown()); 
    }

    private void Update()
    {
        levelDisplay.text = seconds.ToString();

        if (seconds < 0)
            SceneManager.LoadScene("Lose");
    }

    public IEnumerator Countdown()
    {
        while (seconds >= 0)
        {
            yield return new WaitForSeconds(1f);
            seconds--;
        }
    }
}
