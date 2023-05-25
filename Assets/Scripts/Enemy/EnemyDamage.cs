using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage;

    //protected void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        if (collision.gameObject.GetComponent<Transform>().position.y > (transform.position.y + 0.8f))
    //        {
    //            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    //            gameObject.GetComponent<PlayerHealth>()?.TakeDamage(damage);
    //        }
    //        else
    //        {
    //            collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(damage);
    //        }

    //        //gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    //    }
    //    else if (collision.gameObject.CompareTag("Snail"))
    //    {
    //        gameObject.GetComponent<PlayerHealth>()?.TakeDamage(damage);
    //    }
    //}

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>()?.TakeDamage(damage);
        }
    }
}
