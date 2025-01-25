using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChestView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private ChestScriptableObject chestSO;

    [SerializeField] private ChestItem chestItem;
    [SerializeField] private TextMeshProUGUI chestStateText;
    [SerializeField] private Image chestImage;
    private ChestType chestType;
    private RangeInt coinRange;
    private RangeInt gemRange;
    private int unlockTime;     //timer in minutes

    private ChestController chestController;

    private Coroutine timerCoroutine;
    private int hours, minutes, seconds, totalSeconds;

    public void InitializeChestData(ChestController chestController, ChestScriptableObject chestSO)
    {
        chestItem.SetController(chestController);
        this.chestSO = chestSO;

        this.chestImage.sprite = chestSO.ChestImage;
        this.chestType = chestSO.ChestType;
        this.coinRange = chestSO.CoinRange;
        this.gemRange = chestSO.GemRange;
        this.unlockTime = chestSO.UnlockTime;

        chestStateText.text = "Locked";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameService.Instance.UIService.OpenPopup(PopupType.Chest_Hover_Popup, chestSO, chestItem);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameService.Instance.UIService.CloseHoverPopup();
    }

    public void UpdateTimerUI(float remainingTime)
    {
        totalSeconds = Mathf.CeilToInt(remainingTime);
        hours = totalSeconds / 3600;
        minutes = (totalSeconds % 3600) / 60;
        seconds = totalSeconds % 60;

        chestStateText.text = $"{hours:00}:{minutes:00}:{seconds:00}";
    }

    public ChestScriptableObject GetChestData() => chestSO;

    public int GetCurrentTime() => (hours * 60 + minutes);

    public void SetChestStateText(string text) => chestStateText.text = text;

    public void SetChestID(int chestID) => chestItem.SetID(chestID);
}