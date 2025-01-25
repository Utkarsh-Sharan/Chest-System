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
    private int chestTimeToGems;

    private void Start()
    {
        closeButton.onClick.AddListener(ClosePopup);
        buyButton.onClick.AddListener(() => BuyChest(chestView));
    }

    public override void Setup(ChestScriptableObject chestData, ChestItem chestItem)
    {
        if(chestItem.GetChestState() == ChestStates.Locked)
            chestTimeToGems = (int)Mathf.Ceil(chestData.UnlockTime / (float)minutesPerGem);

        else
            chestTimeToGems = (int)Mathf.Ceil(chestItem.GetCurrentTime() / (float)minutesPerGem);

        chestUnlockText.text = $"Unlock with {chestTimeToGems} gems?";
    }

    private void BuyChest(ChestItem chestItem)
    {
        if (GameService.Instance.CurrencyService.IsSufficientGemsAvailable(chestTimeToGems))
        {
            chestItem.ChangeState(ChestStates.Unlocked);
            chestItem.SetChestStateText("Collect");
        }

        ClosePopup();
    }
}
