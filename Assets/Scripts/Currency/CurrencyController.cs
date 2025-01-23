using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentCoinsText;
    [SerializeField] private TextMeshProUGUI currentGemsText;
    private int coinValue = 0 , gemValue = 0;
    private const int minutesPerGem = 10;

    public void CollectReward(ChestView chestView)
    {
        ChestScriptableObject chestData = chestView.GetChestData();

        coinValue += chestData.CoinRange.GetRandomValue();
        gemValue += chestData.GemRange.GetRandomValue();

        UpdateCurrency();
    }

    public void UnlockChestWithGems(ChestView chestView)
    {
        int chestTimeToUnlock = (int)Mathf.Ceil(chestView.GetCurrentTime() / minutesPerGem);
        gemValue -= chestTimeToUnlock;

        UpdateCurrency();
    }

    private void UpdateCurrency()
    {
        currentCoinsText.text = $"{coinValue}";
        currentGemsText.text = $"{gemValue}";
    }
}
