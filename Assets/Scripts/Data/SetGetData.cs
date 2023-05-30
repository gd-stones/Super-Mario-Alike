using UnityEngine;

public class SetGetData : MonoBehaviour
{
    //public Color colorValue;
    //public float speedValue;

    //public void SaveOnClick()
    //{
    //    DataManager.Instance.color = colorValue;
    //    DataManager.Instance.speed = speedValue;
    //    DataManager.Instance.WriteData();
    //}

    //public void LoadOnClick()
    //{
    //    DataManager.Instance.LoadData();
    //    colorValue = DataManager.Instance.color;
    //    speedValue = DataManager.Instance.speed;
    //}

    private void Start()
    {
        DataManager.Instance.LoadData();
    }

    private void Update()
    {
        DataManager.Instance.coin = Coin.totalCoin;
        DataManager.Instance.WriteData();
    }
}
