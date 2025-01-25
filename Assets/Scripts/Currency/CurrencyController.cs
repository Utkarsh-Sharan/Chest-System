using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentCoinsText;
    [SerializeField] private TextMeshProUGUI currentGemsText;
    private int coinValue = 0 , gemValue = 0, chestTimeToGems;
    private const int minutesPerGem = 10;

    public void CollectReward(int coins, int gems)
    {
        coinValue += coins;
        gemValue += gems;

        UpdateCurrency();
    }

    public bool IsSuffecientGemsAvailable(int chestTimeToGems)
    {
        if (chestTimeToGems <= gemValue)
        {
            UnlockChestWithGems(chestTimeToGems);
            return true;
        }

        //popup showing not enough gems.
        Debug.Log("Not enough gems!");
        return false;
    }

    private void UnlockChestWithGems(int chestTimeToGems)
    {
        gemValue -= chestTimeToGems;
        UpdateCurrency();
    }

    private void UpdateCurrency()
    {
        currentCoinsText.text = $"{coinValue}";
        currentGemsText.text = $"{gemValue}";
    }
}
