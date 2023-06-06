using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public Text levelDisplay;
    public int seconds = 180;

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

    private IEnumerator Countdown()
    {
        while (seconds >= 0)
        {
            Debug.Log(seconds);
            yield return new WaitForSeconds(1f);
            seconds--;
        }
    }
}
