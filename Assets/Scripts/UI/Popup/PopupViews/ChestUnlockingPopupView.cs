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

    public override void Setup(ChestView chestView)
    {
        chestStateText.text = "Chest is currently Locked!";
        closeButton.onClick.AddListener(ClosePopup);

        startTimerButton.onClick.RemoveAllListeners();
        startTimerButton.onClick.AddListener(() => StartTimer(chestView));
        unlockWithGemsButton.onClick.RemoveAllListeners();
        unlockWithGemsButton.onClick.AddListener(() => BuyChest(chestView));
    }

    private void StartTimer(ChestView chestView)
    {
        chestView.StartTimer();
        ClosePopup();
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
