using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChestHoverPopupView : PopupView
{
    [SerializeField] private TextMeshProUGUI chestTypeText;
    [SerializeField] private TextMeshProUGUI coinRangeText;
    [SerializeField] private TextMeshProUGUI gemRangeText;

    public override void Setup(ChestView chestView)
    {
        chestTypeText.text = $"This is a {chestView.GetChestData().ChestType} chest.";
        coinRangeText.text = $"X {chestView.GetChestData().CoinRange.Min}-{chestView.GetChestData().CoinRange.Max}";
        gemRangeText.text = $"X {chestView.GetChestData().GemRange.Min}-{chestView.GetChestData().GemRange.Max}";
    }
}
