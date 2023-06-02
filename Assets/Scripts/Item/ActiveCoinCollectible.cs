using UnityEngine;
using System.Collections;

public class ActiveCoinCollectible : MonoBehaviour
{
    [SerializeField] private GameObject coinCollectible;
    private float brickFootCoordinateY;
    private float playerHeadCoordinateY;
    private static bool hasSpawnedCoin = false;

    private Vector3 initialPosition;
    public float moveSpeed = 5f;

    private void Start()
    {
        brickFootCoordinateY = transform.position.y - 0.5f;
        initialPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(hasSpawnedCoin);

        if (collision.gameObject.tag == "Player")
        {
            playerHeadCoordinateY = collision.gameObject.GetComponent<Transform>().position.y + 0.5f;
            if (brickFootCoordinateY >= playerHeadCoordinateY && !hasSpawnedCoin)
            {
                coinCollectible.SetActive(true);
                hasSpawnedCoin = true;
                StartCoroutine(ResetCoinSpawn());

                StartCoroutine(MoveBrick());
            }
        }
    }

    private IEnumerator ResetCoinSpawn()
    {
        yield return new WaitForSeconds(0.3f);
        hasSpawnedCoin = false;
        Destroy(this);
    }

    private IEnumerator MoveBrick()
    {
        Vector3 targetPosition = transform.position + new Vector3(0, 0.4f, 0);
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed);
            yield return null;
        }

        while (transform.position != initialPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, Time.deltaTime * moveSpeed);
            yield return null;
        }
    }
}
