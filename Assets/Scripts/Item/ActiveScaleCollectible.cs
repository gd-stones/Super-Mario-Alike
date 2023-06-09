using System.Collections;
using UnityEngine;

public class ActiveScaleCollectible : MonoBehaviour
{
    [SerializeField] private GameObject scaleCollectible;
    [SerializeField] private float moveDuration = 5f;
    private float brickFootCoordinateY;
    private float playerHeadCoordinateY;

    private Vector3 initialPosition;
    private float moveSpeedBrick = 2f;

    public bool headCollision = false;

    private void Start()
    {
        brickFootCoordinateY = transform.position.y - 0.5f;
        initialPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (headCollision)
            return;

        if (collision.gameObject.tag == "Player")
        {
            playerHeadCoordinateY = collision.gameObject.GetComponent<Transform>().position.y + 0.5f;

            if (brickFootCoordinateY >= playerHeadCoordinateY)
            {
                headCollision = true;
                StartCoroutine(MoveBrick());
                scaleCollectible.SetActive(true);
            }
        }
    }

    private IEnumerator MoveBrick()
    {
        Vector3 targetPosition = transform.position + new Vector3(0, 0.4f, 0);
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeedBrick);
            yield return null;
        }

        while (transform.position != initialPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, Time.deltaTime * moveSpeedBrick);
            yield return null;
        }
    }
}
