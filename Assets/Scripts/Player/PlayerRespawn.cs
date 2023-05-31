using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    private Transform currentCheckpoint; //Store last checkpoint
    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (gameObject.GetComponent<PlayerHealth>().currentHealth <= 0 || transform.position.y < -10)
        {
            CheckRespawn();
        }
    }

    public void CheckRespawn()
    {
        if (currentCheckpoint == null) //Check is checkpoint available
        {
            //SceneManager.LoadScene("Lose");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }

        transform.position = currentCheckpoint.position; //Move player to checkpoint position
        playerHealth.Respawn(); //restore player health and reset animation
    }

    private void OnTriggerEnter2D(Collider2D collision) //activate checkpoints
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform; //store the checkpoint that we activated as the current one
            //SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false; //deactivate checkpoint collider
            collision.GetComponent<Animator>().SetTrigger("checkpoint_Appear"); //trigger checkpoint animation
        }
        else if (collision.transform.tag == "Start")
        {
            collision.GetComponent<Animator>().SetTrigger("start_Appear");
        }
        else if (collision.transform.tag == "End")
        {
            collision.GetComponent<Animator>().SetTrigger("end_Appear");
            StartCoroutine(LoadSceneWithDelay(1.25f));
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
        string sceneNumberString = currentSceneName.Substring(currentSceneName.Length - 1);
        int sceneNumber = int.Parse(sceneNumberString);
        int nextSceneNumber = sceneNumber + 1;
        string nextSceneName = currentSceneName.Substring(0, currentSceneName.Length - 1) + nextSceneNumber.ToString();

        SceneManager.LoadScene(nextSceneName);
    }
}
