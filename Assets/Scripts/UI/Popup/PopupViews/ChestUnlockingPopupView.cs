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
    [SerializeField] private TextMeshProUGUI unlockWithGemsText;
    private int chestTimeToGems;
    private ChestItem chestItem;

    private void Start()
    {
        closeButton.onClick.AddListener(ClosePopup);
        startTimerButton.onClick.AddListener(StartTimer);
        unlockWithGemsButton.onClick.AddListener(BuyChest);
    }

    public override void Setup(ChestScriptableObject chestData, ChestItem chestItem)
    {
        this.chestItem = chestItem;

        if (chestItem.GetChestState() == ChestStates.Locked)
            chestTimeToGems = (int)Mathf.Ceil(chestData.UnlockTime / (float)minutesPerGem);

        else
            chestTimeToGems = (int)Mathf.Ceil(chestItem.GetCurrentTime() / (float)minutesPerGem);

        chestStateText.text = "Chest is currently Locked!";
        unlockWithGemsText.text = $"Unlock with {chestTimeToGems}";
    }

    private void StartTimer()
    {
        chestItem.StartTimer();
        ClosePopup();
    }

    private void BuyChest()
    {
        if (GameService.Instance.CurrencyService.IsSufficientGemsAvailable(chestTimeToGems))
        {
            chestItem.ChangeState(ChestStates.Unlocked);
            chestItem.SetChestStateText("Collect");
        }

        ClosePopup();
    }
}
