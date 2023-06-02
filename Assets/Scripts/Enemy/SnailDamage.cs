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
    private Coroutine currentMovementCoroutine;

    private void Start()
    {
        snailHeadCoordinateY = transform.position.y + 0.25f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerFootCoordinateY = collision.gameObject.transform.position.y;
            playerCoordinateX = collision.gameObject.transform.position.x;
            snailCoordinateX = transform.position.x;

            if (playerFootCoordinateY > snailHeadCoordinateY && playerCoordinateX <= snailCoordinateX)
            {
               StartCoroutine(MoveObjectToDirection(gameObject, 2f, Vector3.right));
            }
            else if (playerFootCoordinateY > snailHeadCoordinateY && playerCoordinateX > snailCoordinateX)
            {
                StartCoroutine(MoveObjectToDirection(gameObject, 2f, Vector3.left));
            }
            else
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            hitWall = true;
        }
    }

    IEnumerator MoveObjectToDirection(GameObject objectToMove, float speed, Vector3 direction)
    {
        float distanceToMove = speed * Time.deltaTime;
        float elapsedTime = 0f;

        while (elapsedTime < 4f)
        {
            if (hitWall)
            {
                if (direction == Vector3.right)
                    direction = Vector3.left;
                else if (direction == Vector3.left)
                    direction = Vector3.right;
            }

            hitWall = false;

            objectToMove.transform.Translate(direction * distanceToMove);
            gameObject.GetComponent<EnemyPatrol>().enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("snail_Hurt");
            isInShell = true;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isInShell = false;
        gameObject.GetComponent<Animator>().SetBool("snail_Walk", true);
        gameObject.GetComponent<EnemyPatrol>().enabled = true;
    }
}
