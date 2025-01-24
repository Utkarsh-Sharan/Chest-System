using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestBuyPopupView : PopupView
{
    [SerializeField] private TextMeshProUGUI chestUnlockText;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button buyButton;
    private const int minutesPerGem = 10;

    public override void Setup(ChestView chestView)
    {
        if(chestView.GetChestState() == ChestStates.Locked)
            chestUnlockText.text = $"Unlock with {(int)Mathf.Ceil(chestView.GetChestData().UnlockTime / (float)minutesPerGem)} gems?";    //static class utility
        else
            chestUnlockText.text = $"Unlock with {(int)Mathf.Ceil(chestView.GetCurrentTime() / (float)minutesPerGem)} gems?";

        closeButton.onClick.AddListener(ClosePopup);
        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(() => BuyChest(chestView));
    }

    private void BuyChest(ChestView chestView)
    {
        if (GameService.Instance.CurrencyService.IsSufficientGemsAvailable(chestView))
        {
            chestView.ChangeState(ChestStates.Unlocked);
            chestView.SetChestStateText("Collect");
        }

        ClosePopup();
    }
}
