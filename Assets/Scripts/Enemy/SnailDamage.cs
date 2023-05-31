using System.Collections;
using UnityEngine;

public class SnailDamage : MonoBehaviour
{
    [SerializeField] protected float damage;
    private float snailHeadCoordinateY;
    private float playerFootCoordinateY;
    private float playerCoordinateX;
    private float snailCoordinateX;

    private void Start()
    {
        snailHeadCoordinateY = transform.position.y + 0.25f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerFootCoordinateY = collision.gameObject.GetComponent<Transform>().position.y;
            playerCoordinateX = collision.gameObject.GetComponent<Transform>().position.x;
            snailCoordinateX = gameObject.GetComponent<Transform>().position.x;

            if (playerFootCoordinateY > snailHeadCoordinateY && playerCoordinateX <= snailCoordinateX)
            {
                StartCoroutine(MoveObjectToDirection(gameObject, 1f, Vector3.right));
            }
            else if (playerFootCoordinateY > snailHeadCoordinateY && playerCoordinateX > snailCoordinateX)
            {
                StartCoroutine(MoveObjectToDirection(gameObject, 1f, Vector3.left));
            }
            else
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
        }
    }

    IEnumerator MoveObjectToDirection(GameObject objectToMove, float speed, Vector3 direction)
    {
        float distanceToMove = speed * Time.deltaTime;
        float elapsedTime = 0f;

        while (elapsedTime < 5f)
        {
            objectToMove.transform.Translate(direction * distanceToMove);
            gameObject.GetComponent<EnemyPatrol>().enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("snail_Hurt");

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        gameObject.GetComponent<Animator>().SetBool("snail_Walk", true);
        gameObject.GetComponent<EnemyPatrol>().enabled = true;
        //objectToMove.SetActive(false);
    }
}
