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

    public void ChestCollected(ChestView chestView) => currencyController.CollectReward(chestView);

    public bool IsSufficientGemsAvailable(ChestView chestView) => currencyController.IsSuffecientGemsAvailable(chestView);
}
