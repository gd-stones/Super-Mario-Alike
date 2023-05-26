using UnityEngine;

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
                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                gameObject.GetComponent<EnemyHealth>()?.EnemyTakeDamage();
            }
            else
            {
                collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            }
        }
        else if (collision.gameObject.tag == "Snail")
        {
            gameObject.transform.Translate(Vector3.up * 40 * Time.deltaTime);
            gameObject.GetComponent<EnemyHealth>()?.EnemyTakeDamage();
        }
    }
}
