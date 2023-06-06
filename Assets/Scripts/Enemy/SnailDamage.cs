using System.Collections;
using UnityEngine;

public class SnailDamage : MonoBehaviour
{
    [SerializeField] protected float damage;
    private float snailHeadCoordinateY;
    private float playerFootCoordinateY;
    private float playerCoordinateX;
    private float snailCoordinateX;

    public static bool isInShell = false;
    private bool hitWall = false;
    private bool playerCollided = false;

    private void Start()
    {
        snailHeadCoordinateY = transform.position.y + 0.25f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerFootCoordinateY = collision.transform.position.y;
            playerCoordinateX = collision.transform.position.x;
            snailCoordinateX = transform.position.x;

            if (!playerCollided && playerFootCoordinateY > snailHeadCoordinateY)
            {
                collision.GetComponent<PlayerMovement>().JumpOnEnemyHead();
                playerCollided = true;
                StartCoroutine(EnterShell());
            }
            else if (isInShell)
                StartCoroutine(MoveObjectToDirection(gameObject, 4f, playerCoordinateX <= snailCoordinateX ? Vector3.right : Vector3.left));
            else
                collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        else if (collision.CompareTag("Wall"))
            hitWall = true;
    }

    IEnumerator EnterShell()
    {
        isInShell = true;
        float elapsedTime = 0f;

        while (elapsedTime < 2f)
        {
            gameObject.GetComponent<EnemyPatrol>().enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("snail_Hurt");

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        playerCollided = false;
        if (!playerCollided)
        {
            isInShell = false;
            gameObject.GetComponent<Animator>().SetBool("snail_Walk", true);
            gameObject.GetComponent<EnemyPatrol>().enabled = true;
        }
    }

    IEnumerator MoveObjectToDirection(GameObject objectToMove, float speed, Vector3 direction)
    {
        float distanceToMove = speed * Time.deltaTime;
        float elapsedTime = 0f;
        isInShell = false;

        while (elapsedTime < 3.5f)
        {
            if (hitWall)
                direction = -direction;
            hitWall = false;

            objectToMove.transform.Translate(direction * distanceToMove);
            gameObject.GetComponent<EnemyPatrol>().enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("snail_Hurt");

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        playerCollided = false;
        gameObject.GetComponent<Animator>().SetBool("snail_Walk", true);
        gameObject.GetComponent<EnemyPatrol>().enabled = true;
    }
}
