using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    [SerializeField] private Button generateChestButton;
    [SerializeField] private TextMeshProUGUI messageToasterText;
    private TextMeshProUGUI messageToasterObject;
    private Coroutine messageTimer;

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
            PopupView instantiatedPopupView = Instantiate(popup.PopupView, popupPanel.transform.position, Quaternion.identity, popupPanel.transform);

            instantiatedPopupView.gameObject.SetActive(false);
            instantiatedPopups.Add(popup.PopupType, instantiatedPopupView);
        }

        messageToasterObject = Instantiate(messageToasterText, this.transform.position + new Vector3(0, -245f, 0), Quaternion.identity, this.transform);
        messageToasterObject.gameObject.SetActive(false);
    }

    private void GenerateRandomChest()
    {
        GameService.Instance.ChestService.CreateRandomChest();
    }

    public void ShowMessage(string message)
    {
        if(messageTimer != null)
            StopCoroutine(messageTimer);

        messageTimer = StartCoroutine(StartMessageTimer(message));
    }

    private IEnumerator StartMessageTimer(string message)
    {
        messageToasterObject.text = message;

        messageToasterObject.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        messageToasterObject.gameObject.SetActive(false);
    }

    public void OpenPopup(PopupType popupType, ChestScriptableObject chestData, ChestItem chestItem)
    {
        if(currentlyOpenedPopup != null)
            currentlyOpenedPopup.gameObject.SetActive(false);
        
        if(instantiatedPopups.TryGetValue(popupType, out PopupView popupObject))
        {
            currentlyOpenedPopup = popupObject;
            currentlyOpenedPopup.Setup(chestData, chestItem);
            currentlyOpenedPopup.gameObject.SetActive(true);
        }
    }

    public void CloseHoverPopup()
    {
        if(currentlyOpenedPopup == instantiatedPopups[PopupType.Chest_Hover_Popup])
            currentlyOpenedPopup.gameObject.SetActive(false);
    }
}
