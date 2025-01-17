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

    private Dictionary<PopupType, GameObject> instantiatedPopups;

    private void Start()
    {
        instantiatedPopups = new Dictionary<PopupType, GameObject>();
        generateChestButton.onClick.AddListener(GenerateRandomChest);

        foreach (PopupScriptableObject popup in popupSO)
        {
            GameObject instantiatedPopup = Instantiate(popup.PopupObject, popupPanel.transform.position, Quaternion.identity, popupPanel.transform);
            instantiatedPopup.SetActive(false);
            instantiatedPopups.Add(popup.PopupType, instantiatedPopup);
        }
    }

    private void GenerateRandomChest()
    {
        GameService.Instance.ChestService.CreateRandomChest();
    }

    public void OpenPopupOfType(PopupType popupType, ChestView chestView)
    {
        //take reference of currently open popup.
        foreach (var popup in instantiatedPopups)
        {
            GameObject popupInstance = popup.Value;
            if(popup.Key == popupType)
            {
                popupInstance.SetActive(true);
                popupInstance.GetComponent<PopupView>().Setup(chestView);
            }
            else
                popupInstance.SetActive(false);
        }
    }

    public void CloseAllPopups()
    {
        foreach (var popup in instantiatedPopups)
        {
            GameObject popupInstance = popup.Value;
            popupInstance.SetActive(false);
        }
    }
}
