using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyService
{
    private CurrencyController currencyController;

    public CurrencyService(CurrencyController currencyController)
    {
        this.currencyController = currencyController;
    }

    public void ChestCollected(int coins, int gems) => currencyController.CollectReward(coins, gems);

    public bool IsSufficientGemsAvailable(int chestTimeToGems) => currencyController.IsSuffecientGemsAvailable(chestTimeToGems);
}
