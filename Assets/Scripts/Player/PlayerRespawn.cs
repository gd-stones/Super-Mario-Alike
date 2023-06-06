using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    private Transform currentCheckpoint; // Store last checkpoint
    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        PlayerPrefs.SetString("currentSceneName", SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if (gameObject.GetComponent<PlayerHealth>().currentHealth <= 0 || transform.position.y < -10)
            CheckRespawn();
    }

    private void CheckRespawn()
    {
        if (currentCheckpoint == null) //Check is checkpoint available
        {
            StartCoroutine(LoadLoseScene("Lose", 1f));
            return;
        }

        transform.position = currentCheckpoint.position; // Move player to checkpoint position
        playerHealth.Respawn(); // Restore player health and reset animation
    }

    private void OnTriggerEnter2D(Collider2D collision) // Activate checkpoints
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform; // Store the checkpoint that we activated as the current one
            SoundManager.instance.PlaySound(checkpointSound);

            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("checkpoint_Appear");
        }
        else if (collision.transform.tag == "Start")
        {
            collision.GetComponent<Animator>().SetTrigger("start_Appear");
        }
        else if (collision.transform.tag == "End")
        {
            collision.GetComponent<Animator>().SetTrigger("end_Appear");
            StartCoroutine(LoadSceneWithDelay(1.5f));
        }
    }

    private IEnumerator LoadSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "Level 10")
        {
            SceneManager.LoadScene("Win");
            yield return null;
        }

        int nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);

        SceneManager.LoadScene(nextSceneLoad);
        ScoreCalculator.score = 0;
    }

    private IEnumerator LoadLoseScene(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
