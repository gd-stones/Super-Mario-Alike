using UnityEngine;
using System.Collections;

public class RhinocerosDamage : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float rhinoFootCoordinateY = transform.position.y;
            float rhinoHeadCoordinateY = transform.position.y + 0.2f;

            float playerFootCoordinateY = collision.transform.position.y;
            float playerHeadCoordinateY = collision.transform.position.y + 0.6f;

            if (playerFootCoordinateY >= rhinoHeadCoordinateY)
            {
                gameObject.GetComponent<EnemyHealth>()?.EnemyTakeDamage();
                collision.gameObject.GetComponent<PlayerMovement>().JumpOnEnemyHead();

                ScoreCalculator.score += 5;
            }
            else if (playerFootCoordinateY >= rhinoFootCoordinateY && playerFootCoordinateY < rhinoHeadCoordinateY)
            {
                StartCoroutine(ActiveGoThroughRhino());
                collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(1);

                if (collision.gameObject.GetComponent<PlayerHealth>().currentHealth <= 0)
                {
                    gameObject.GetComponent<RhinocerosMovement>().enabled = false;
                    rb.velocity = Vector3.zero;
                }
            }
            else if (playerHeadCoordinateY <= rhinoFootCoordinateY - 0.15f)
            {
                StartCoroutine(ActiveGoThroughPlayer());
                collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(1);

                if (collision.gameObject.GetComponent<PlayerHealth>().currentHealth <= 0)
                {
                    gameObject.GetComponent<RhinocerosMovement>().enabled = false;
                    rb.velocity = Vector3.zero;
                }
            }
        }
    }

    private IEnumerator ActiveGoThroughRhino()
    {
        float duration = 3f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.GetComponent<CapsuleCollider2D>().isTrigger = true;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        gameObject.GetComponent<CapsuleCollider2D>().isTrigger = false;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    private IEnumerator ActiveGoThroughPlayer()
    {
            float duration = 1f;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                player.GetComponent<BoxCollider2D>().isTrigger = true;

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            player.GetComponent<BoxCollider2D>().isTrigger = false;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
