using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage;
    private float enemyHeadCoordinateY;
    private float playerFootCoordinateY;

    private void Start()
    {
        enemyHeadCoordinateY = transform.position.y + 0.25f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Flower" && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            return;
        }

        if (collision.gameObject.tag == "Player")
        {
            playerFootCoordinateY = collision.transform.position.y;

            if (playerFootCoordinateY > enemyHeadCoordinateY)
            {
                gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                gameObject.GetComponent<EnemyHealth>()?.EnemyTakeDamage();
                collision.gameObject.GetComponent<PlayerMovement>().JumpOnEnemyHead();

                ScoreCalculator.score += 5;
            }
            else
            {
                collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(damage);
                if (collision.gameObject.GetComponent<PlayerHealth>().currentHealth <= 0)
                    gameObject.GetComponent<EnemyPatrol>().enabled = false;
            }
        }
        else if (collision.gameObject.tag == "Snail")
        {
            StartCoroutine(MoveUpAndDown());
        }
    }

    private IEnumerator MoveUpAndDown()
    {
        float duration = 0.5f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            gameObject.transform.Translate(Vector3.up * 3 * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            gameObject.transform.Translate(Vector3.down * 6 * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        gameObject.GetComponent<EnemyHealth>()?.EnemyTakeDamage();
    }
}
