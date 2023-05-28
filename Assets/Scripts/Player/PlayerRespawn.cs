using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound; //sound that we will play when picking up a new checkpoint
    private Transform currentCheckpoint; //we will store our last checkpoint here
    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (gameObject.GetComponent<PlayerHealth>().currentHealth <= 0)
        {
            CheckRespawn();
        }
        if (transform.position.y < -6)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    public void CheckRespawn()
    {
        if (currentCheckpoint == null) //check is check point available
        {
            SceneManager.LoadScene("Lose");
            return; //don't execute the rest of this function
        }

        transform.position = currentCheckpoint.position; // move player to checkpoint position
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
        string sceneNumberString = currentSceneName.Substring(currentSceneName.Length - 1);
        int sceneNumber = int.Parse(sceneNumberString);
        int nextSceneNumber = sceneNumber + 1;
        string nextSceneName = currentSceneName.Substring(0, currentSceneName.Length - 1) + nextSceneNumber.ToString();

        SceneManager.LoadScene(nextSceneName);
    }
}
