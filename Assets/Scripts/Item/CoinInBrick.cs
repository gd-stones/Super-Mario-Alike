using UnityEngine;

public class CoinInBrick : MonoBehaviour
{
    [SerializeField] private int valueCoin;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DataManager.Instance.coin += valueCoin;
            Destroy(gameObject);
        }
    }
}
