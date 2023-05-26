using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailDamage : MonoBehaviour
{
    [SerializeField] protected float damage;
    private float enemyHeadCoordinateY;
    private float playerFootCoordinateY;

    private void Start()
    {
        enemyHeadCoordinateY = transform.position.y + 0.5f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //SnailMovement.die = true;
            playerFootCoordinateY = collision.gameObject.GetComponent<Transform>().position.y;
            if (playerFootCoordinateY > enemyHeadCoordinateY)
            {
                //transform.GetComponent<SnailMovement>().die = true;
                StartCoroutine(MoveObjectToRight(gameObject, 2.5f));
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

        while (elapsedTime < 12f)
        {
            objectToMove.transform.Translate(Vector3.right * distanceToMove);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objectToMove.SetActive(false);
    }
}
