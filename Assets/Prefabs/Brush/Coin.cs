using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int totalCoin = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            totalCoin += 50;
            gameObject.SetActive(false);
        }
    }
}
