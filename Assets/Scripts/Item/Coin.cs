using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int valueCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DataManager.Instance.coin += valueCoin; 
            ScoreCalculator.score += 5;
            Destroy(gameObject);
        }
    }
}
