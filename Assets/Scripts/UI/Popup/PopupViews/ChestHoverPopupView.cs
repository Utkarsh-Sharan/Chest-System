using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChestHoverPopupView : MonoBehaviour, PopupView
{
    [SerializeField] private TextMeshProUGUI chestTypeText;
    [SerializeField] private TextMeshProUGUI coinRangeText;
    [SerializeField] private TextMeshProUGUI gemRangeText;

    public void Setup(ChestView chestView)
    {
        ChestScriptableObject chestData = chestView.GetChestData();
        chestTypeText.text = $"This is a {chestData.ChestType} chest.";
        coinRangeText.text = $"X {chestData.CoinRange.Min}-{chestData.CoinRange.Max}";
        gemRangeText.text = $"X {chestView.GetChestData().GemRange.Min}-{chestView.GetChestData().GemRange.Max}";
    }
}
