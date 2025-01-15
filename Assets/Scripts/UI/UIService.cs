using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    [SerializeField] private Button generateChestButton;

    [Header("Popup Panel")]
    [SerializeField] private GameObject popupPanel;

    [Header("Chest Hover")]
    [SerializeField] private GameObject chestHoverObject;
    [SerializeField] private TextMeshProUGUI chestTypeText;
    [SerializeField] private TextMeshProUGUI coinRangeText;
    [SerializeField] private TextMeshProUGUI gemRangeText;

    [Header("Chest Click")]
    [SerializeField] private GameObject chestClickedObject;

    private void Start()
    {
        generateChestButton.onClick.AddListener(GenerateRandomChest);
    }

    private void GenerateRandomChest()
    {
        GameService.Instance.ChestService.CreateRandomChest();
    }

    public void ShowChestDataOnHover(ChestView chestView)
    {
        OpenPopupPanel();
        chestHoverObject.SetActive(true);
        chestTypeText.text = $"This is a {chestView.GetChestData().ChestType} chest.";
        coinRangeText.text = $"X {chestView.GetChestData().CoinRange.Min}-{chestView.GetChestData().CoinRange.Max}";
        gemRangeText.text = $"X {chestView.GetChestData().GemRange.Min}-{chestView.GetChestData().GemRange.Max}";
    }

    public void ShowChestStateOnClick()
    {
        OpenPopupPanel();
        chestClickedObject.SetActive(true);
    }

    private void OpenPopupPanel() => popupPanel.SetActive(true);

    public void ClosePopupPanel() => popupPanel.SetActive(false);
}
