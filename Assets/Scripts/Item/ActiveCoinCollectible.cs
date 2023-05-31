using UnityEngine;

public class ActiveCoinCollectible : MonoBehaviour
{
    [SerializeField] private GameObject coinCollectible;
    private float brickFootCoordinateY;
    private float playerHeadCoordinateY;

    private void Start()
    {
        brickFootCoordinateY = transform.position.y - 0.5f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHeadCoordinateY = collision.gameObject.GetComponent<Transform>().position.y + 0.5f;
            if (brickFootCoordinateY >= playerHeadCoordinateY)
            {
                coinCollectible.SetActive(true);
                Destroy(this);
            }
        }
    }
}
