using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestClickedPopupView : PopupView
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
    }

    private void StartTimer(ChestView chestView)
    {
        chestView.StartTimer();
        this.gameObject.SetActive(false);
    }
}
