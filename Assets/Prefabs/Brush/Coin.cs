using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int totalCoin = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DataManager.Instance.coin += 50;
            gameObject.SetActive(false);
        }
    }
}
