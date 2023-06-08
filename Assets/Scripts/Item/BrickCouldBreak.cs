using UnityEngine;
using System.Collections;

public class BrickCouldBreak : MonoBehaviour
{
    private float brickFootCoordinateY;
    private float playerHeadCoordinateY;
    private Vector3 brickInitPos;
    public float moveSpeed = 5f;

    private static bool isMoving = false;

    private void Start()
    {
        brickFootCoordinateY = transform.position.y - 0.5f;
        brickInitPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHeadCoordinateY = collision.gameObject.GetComponent<Transform>().position.y + 0.5f;

            if (brickFootCoordinateY >= playerHeadCoordinateY && !isMoving)
            {
                isMoving = true;
                StartCoroutine(MoveBrick(collision));
                StartCoroutine(ResetBrickMovement());
            }
        }
    }

    private IEnumerator ResetBrickMovement()
    {
        yield return new WaitForSeconds(0.3f);
        isMoving = false;
    }

    private IEnumerator MoveBrick(Collision2D collision)
    {
        Vector3 targetPos = transform.position + new Vector3(0, 0.4f, 0);

        while (transform.position != targetPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * moveSpeed);
            yield return null;
        }

        while (transform.position != brickInitPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, brickInitPos, Time.deltaTime * moveSpeed);
            yield return null;
        }

        // Break brick if player is scaling
        if (collision.transform.localScale.x > 1)
        {
            isMoving = false;
            gameObject.SetActive(false);
        }
    }
}
