using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage;
    private float enemyHeadCoordinateY;
    private float playerFootCoordinateY;

    private void Start()
    {
        enemyHeadCoordinateY = transform.position.y + 0.5f;
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerFootCoordinateY = collision.gameObject.GetComponent<Transform>().position.y;

            if (playerFootCoordinateY > enemyHeadCoordinateY)
            {
                gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                gameObject.GetComponent<EnemyHealth>()?.EnemyTakeDamage();
            }
            else
            {
                collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            }
        }
        else if (collision.gameObject.tag == "Snail")
        {
            StartCoroutine(MoveUpAndDown());
            //gameObject.GetComponent<EnemyHealth>()?.EnemyTakeDamage();
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
