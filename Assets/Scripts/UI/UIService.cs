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
    [SerializeField] private List<PopupScriptableObject> popupSO;

    [Header("Chest Hover")]
    //[SerializeField] private GameObject chestHoverObject;
    [SerializeField] private TextMeshProUGUI chestTypeText;
    [SerializeField] private TextMeshProUGUI coinRangeText;
    [SerializeField] private TextMeshProUGUI gemRangeText;

    [Header("Chest Click")]
    [SerializeField] private GameObject chestClickedObject;

    private void Start()
    {
        generateChestButton.onClick.AddListener(GenerateRandomChest);
        foreach (PopupScriptableObject popup in popupSO)
        {
            Instantiate(popup.PopupObject, popupPanel.transform.position, Quaternion.identity, popupPanel.transform);
            popup.PopupObject.SetActive(false);
        }
    }

    private void GenerateRandomChest()
    {
        GameService.Instance.ChestService.CreateRandomChest();
    }

    public void OpenPopupOfType(PopupType popupType)
    {
        foreach (PopupScriptableObject popup in popupSO)
        {
            if(popup.PopupType == popupType)
                popup.PopupObject.SetActive(true);
            else
                popup.PopupObject.SetActive(false);
        }
    }

    public void ShowChestDataOnHover(ChestView chestView)
    {
        //OpenPopupPanel();
        //chestHoverObject.SetActive(true);
        chestTypeText.text = $"This is a {chestView.GetChestData().ChestType} chest.";
        coinRangeText.text = $"X {chestView.GetChestData().CoinRange.Min}-{chestView.GetChestData().CoinRange.Max}";
        gemRangeText.text = $"X {chestView.GetChestData().GemRange.Min}-{chestView.GetChestData().GemRange.Max}";
    }

    public void ShowChestStateOnClick()
    {
        //OpenPopupPanel();
        chestClickedObject.SetActive(true);
    }

    //private void OpenPopupPanel() => popupPanel.SetActive(true);

    public void ClosePopupPanel()
    {
        //chestHoverObject.SetActive(false);
        chestClickedObject.SetActive(false);
        popupPanel.SetActive(false);
    }
}
