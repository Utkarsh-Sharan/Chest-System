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

    private ChestView chestView;

    public override void Setup(ChestView chestView)
    {
        this.chestView = chestView;

        chestStateText.text = "Chest is currently Locked!";
        closeButton.onClick.AddListener(ClosePopup);
        startTimerButton.onClick.AddListener(StartTimer);
    }

    private void StartTimer()
    {
        chestView.StartTimer();
        this.gameObject.SetActive(false);
    }
}
