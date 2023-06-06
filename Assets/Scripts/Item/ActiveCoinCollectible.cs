using UnityEngine;
using System.Collections;

public class ActiveCoinCollectible : MonoBehaviour
{
    [SerializeField] private GameObject coinCollectible;
    private float brickFootCoordinateY;
    private float playerHeadCoordinateY;
    private static bool hasSpawnedCoin = false;

    private Vector3 brickInitPos;
    private Vector3 coinInitPos;
    public float moveSpeed = 5f;
    private Quaternion coinInitRotation;
    public float rotationSpeed = 30f;

    private int coinCount = 0;
    public int maxCoinCount = 5;

    [SerializeField] private int valueCoin = 50;

    private void Start()
    {
        brickFootCoordinateY = transform.position.y - 0.5f;
        brickInitPos = transform.position;
        coinInitPos = coinCollectible.transform.position;
        coinInitRotation = coinCollectible.transform.rotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (coinCount >= maxCoinCount)
                return;

            playerHeadCoordinateY = collision.gameObject.GetComponent<Transform>().position.y + 0.5f;
            
            if (brickFootCoordinateY >= playerHeadCoordinateY && !hasSpawnedCoin)
            {
                hasSpawnedCoin = true;
                coinCount++;

                StartCoroutine(ResetCoinSpawn());
                StartCoroutine(MoveBrick());
                StartCoroutine(MoveCoin());

                ScoreCalculator.score += 5;
            }
        }
    }

    private IEnumerator ResetCoinSpawn()
    {
        yield return new WaitForSeconds(0.3f);
        hasSpawnedCoin = false;
    }

    private IEnumerator MoveBrick()
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
    }
    
    private IEnumerator MoveCoin()
    {
        coinCollectible.SetActive(true);
        Vector3 targetPos = coinCollectible.transform.position + new Vector3(0, 2f, 0);
        Quaternion targetRotation = Quaternion.Euler(0f, 180f, 0f);

        while (coinCollectible.transform.position != targetPos)
        {
            coinCollectible.transform.position = Vector3.MoveTowards(coinCollectible.transform.position, targetPos, Time.deltaTime * moveSpeed);
            coinCollectible.transform.rotation = Quaternion.RotateTowards(coinCollectible.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            
            yield return null;
        }

        DataManager.Instance.coin += valueCoin;

        while (coinCollectible.transform.position != (targetPos - new Vector3(0, 0.3f, 0)))
        {
            coinCollectible.transform.position = Vector3.MoveTowards(coinCollectible.transform.position, (targetPos - new Vector3(0, 0.3f, 0)), Time.deltaTime * moveSpeed);
            yield return null;
        }

        if (coinCount == maxCoinCount)
        {
            coinCollectible.SetActive(false);
        }

        coinCollectible.SetActive(false);

        coinCollectible.transform.position = coinInitPos;
        coinCollectible.transform.rotation = coinInitRotation;
    }
}
