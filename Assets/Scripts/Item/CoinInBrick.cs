using UnityEngine;
using System.Collections;

public class CoinInBrick : MonoBehaviour
{
    [SerializeField] private int valueCoin;
    private int coinCount = 0;
    [SerializeField] private ActiveCoinCollectible maxCoinCount;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DataManager.Instance.coin += valueCoin;
            coinCount++;

            if (coinCount == maxCoinCount.maxCoinCount)
                Destroy(gameObject);
            else 
                gameObject.SetActive(false);
        }
    }

    //private IEnumerator MoveCoin()
    //{
    //    Vector3 targetPosition = transform.position + new Vector3(0, 0.4f, 0);
    //    while (transform.position != targetPosition)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed);
    //        yield return null;
    //    }

    //    while (transform.position != initialPosition)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, initialPosition, Time.deltaTime * moveSpeed);
    //        yield return null;
    //    }
    //}
}
