using UnityEngine;
using System.Collections;

public class RhinocerosDamage : MonoBehaviour
{
    private float rhinoHeadCoordinateY;
    private float playerFootCoordinateY;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rhinoHeadCoordinateY = transform.position.y + 0.2f;
            playerFootCoordinateY = collision.transform.position.y;

            if (playerFootCoordinateY >= rhinoHeadCoordinateY)
            {
                gameObject.GetComponent<EnemyHealth>()?.EnemyTakeDamage();
                collision.gameObject.GetComponent<PlayerMovement>().JumpOnEnemyHead();

                ScoreCalculator.score += 5;
            }
            else
            {
                StartCoroutine(ActiveGoThrough());
                collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(1);

                if (collision.gameObject.GetComponent<PlayerHealth>().currentHealth <= 0)
                {
                    gameObject.GetComponent<RhinocerosMovement>().enabled = false;
                    rb.velocity = Vector3.zero;
                }
            }
        }
    }

    private IEnumerator ActiveGoThrough()
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
}
