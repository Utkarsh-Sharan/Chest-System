using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestUnlockingPopupView : PopupView
{
    [SerializeField] private TextMeshProUGUI chestStateText;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button startTimerButton;
    [SerializeField] private Button unlockWithGemsButton;
    private const int minutesPerGem = 10;
    private int chestTimeToGems;

    public override void Setup(ChestScriptableObject chestData, ChestItem chestItem)
    {
        if (chestItem.GetChestState() == ChestStates.Locked)
            chestTimeToGems = (int)Mathf.Ceil(chestData.UnlockTime / (float)minutesPerGem);

        else
            chestTimeToGems = (int)Mathf.Ceil(chestItem.GetCurrentTime() / (float)minutesPerGem);

        chestStateText.text = "Chest is currently Locked!";
        closeButton.onClick.AddListener(ClosePopup);

        startTimerButton.onClick.RemoveAllListeners();
        startTimerButton.onClick.AddListener(() => StartTimer(chestItem));
        unlockWithGemsButton.onClick.RemoveAllListeners();
        unlockWithGemsButton.onClick.AddListener(() => BuyChest(chestItem));
    }

    private void StartTimer(ChestItem chestItem)
    {
        chestItem.StartTimer();
        ClosePopup();
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
