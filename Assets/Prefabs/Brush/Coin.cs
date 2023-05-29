using UnityEngine;

public class Coin : MonoBehaviour
{
    private static Coin instance;
    public static int totalCoin = 0;

    private void Awake()
    {
        //if (instance == null)
        //{
        //    instance = this;
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            totalCoin += 50;
            gameObject.SetActive(false);
            print("Current total coin: " + totalCoin);
        }
    }
}
