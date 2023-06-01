using UnityEngine;
using System.Collections;

public class ActiveCoinCollectible : MonoBehaviour
{
    [SerializeField] private GameObject coinCollectible;
    private float brickFootCoordinateY;
    private float playerHeadCoordinateY;
    private static bool hasSpawnedCoin = false;

    private void Start()
    {
        brickFootCoordinateY = transform.position.y - 0.5f;
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
            }
        }
    }

    private IEnumerator ResetCoinSpawn()
    {
        yield return new WaitForSeconds(0.3f);
        hasSpawnedCoin = false;
        Destroy(this);
    }
}
