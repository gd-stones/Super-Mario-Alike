using UnityEngine;
using UnityEngine.UI;

public class DisplayCoin : MonoBehaviour
{
    [SerializeField] private Text coinDisplay;

    private void Start()
    {
        DataManager.Instance.LoadData();
        coinDisplay.text = DataManager.Instance.coin.ToString();
    }

    private void Update()
    {
        coinDisplay.text = DataManager.Instance.coin.ToString();
        DataManager.Instance.WriteData();
    }
}
