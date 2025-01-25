using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChestHoverPopupView : PopupView
{
    [SerializeField] private TextMeshProUGUI chestTypeText;
    [SerializeField] private TextMeshProUGUI coinRangeText;
    [SerializeField] private TextMeshProUGUI gemRangeText;

    public override void Setup(ChestScriptableObject chestData, ChestItem chestItem)
    {
        chestTypeText.text = $"The {chestData.ChestType} chest.";
        coinRangeText.text = $"X {chestData.CoinRange.Min}-{chestData.CoinRange.Max}";
        gemRangeText.text = $"X {chestData.GemRange.Min}-{chestData.GemRange.Max}";
    }
}
