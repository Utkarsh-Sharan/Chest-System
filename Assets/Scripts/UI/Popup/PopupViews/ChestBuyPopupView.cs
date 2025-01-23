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

    public override void Setup(ChestView chestView)
    {
        chestUnlockText.text = $"Unlock with {(int)Mathf.Ceil(chestView.GetCurrentTime())} gems?";

        closeButton.onClick.AddListener(ClosePopup);
        buyButton.onClick.AddListener(() => BuyChest(chestView));
    }

    private void BuyChest(ChestView chestView)
    {
        GameService.Instance.CurrencyService.UnlockChestWithGems(chestView);
    }
}
