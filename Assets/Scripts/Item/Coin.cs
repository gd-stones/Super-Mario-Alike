using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int valueCoin;
    [SerializeField] private AudioClip itemSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(itemSound);
            DataManager.Instance.coin += valueCoin;
            ScoreCalculator.score += 5;
            Destroy(gameObject);
        }
    }
}
