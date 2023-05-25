using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage;
    private float enemyHeadCoordinateY;
    private float playerFootCoordinateY;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        //enemyHeadCoordinateY = transform.position.y + boxCollider.size.y;
        enemyHeadCoordinateY = transform.position.y + 0.5f;
    }

    //protected void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        playerFootCoordinateY = collision.gameObject.GetComponent<Transform>().position.y;

    //        print("enemyHead " + enemyHeadCoordinateY);
    //        print("playerFoot " + playerFootCoordinateY);


    //        if (playerFootCoordinateY > enemyHeadCoordinateY)
    //        {
    //            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    //            gameObject.GetComponent<EnemyHealth>()?.EnemyTakeDamage();
    //        }
    //        else
    //        {
    //            collision.GetComponent<PlayerHealth>()?.TakeDamage(damage);
    //        }
    //    }
    //}

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
            collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(damage);
        }
    }
}
