using System.Collections;
using UnityEngine;

public class SnailDamage : MonoBehaviour
{
    [SerializeField] protected float damage;
    private float snailHeadCoordinateY;
    private float playerFootCoordinateY;

    private void Start()
    {
        snailHeadCoordinateY = transform.position.y + 0.5f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerFootCoordinateY = collision.gameObject.GetComponent<Transform>().position.y;

            if (playerFootCoordinateY > snailHeadCoordinateY)
            {
                StartCoroutine(MoveObjectToRight(gameObject, 1f));
            }
            else
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
        }
    }

    IEnumerator MoveObjectToRight(GameObject objectToMove, float speed)
    {
        float distanceToMove = speed * Time.deltaTime;
        float elapsedTime = 0f;

        while (elapsedTime < 5f)
        {
            objectToMove.transform.Translate(Vector3.right * distanceToMove);
            gameObject.GetComponent<EnemyPatrol>().enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("snail_Hurt");

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objectToMove.SetActive(false);
    }
}
