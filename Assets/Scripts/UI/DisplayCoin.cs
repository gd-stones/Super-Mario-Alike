using UnityEngine;
using UnityEngine.UI;

public class DisplayCoin : MonoBehaviour
{
    [SerializeField] private Text coinDisplay;

    private void Start()
    {
        coinDisplay.text = Coin.totalCoin.ToString();
    }

    private void Update()
    {
        coinDisplay.text = Coin.totalCoin.ToString();
    }
}
