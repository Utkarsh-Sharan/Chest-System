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

    private Dictionary<PopupType, PopupView> instantiatedPopups;
    private PopupView currentlyOpenedPopup;

    private void Start()
    {
        instantiatedPopups = new Dictionary<PopupType, PopupView>();
        generateChestButton.onClick.AddListener(GenerateRandomChest);

        foreach (PopupScriptableObject popup in popupSO)
        {
            GameObject instantiatedPopupObject = Instantiate(popup.PopupObject, popupPanel.transform.position, Quaternion.identity, popupPanel.transform);
            PopupView instantiatedPopupView = instantiatedPopupObject.GetComponent<PopupView>();

            instantiatedPopupObject.SetActive(false);
            instantiatedPopups.Add(popup.PopupType, instantiatedPopupView);
        }
    }

    private void GenerateRandomChest()
    {
        GameService.Instance.ChestService.CreateRandomChest();
    }

    public void OpenPopupOfType(PopupType popupType, ChestView chestView)
    {
        if(currentlyOpenedPopup != null)
            currentlyOpenedPopup.gameObject.SetActive(false);
        
        if(instantiatedPopups.TryGetValue(popupType, out PopupView popupObject))
        {
            currentlyOpenedPopup = popupObject;
            currentlyOpenedPopup.gameObject.SetActive(true);
            currentlyOpenedPopup.Setup(chestView);
        }
    }

    public void CloseHoverPopup()
    {
        if(currentlyOpenedPopup == instantiatedPopups[PopupType.Chest_Hover_Popup])
            currentlyOpenedPopup.gameObject.SetActive(false);
    }
}
