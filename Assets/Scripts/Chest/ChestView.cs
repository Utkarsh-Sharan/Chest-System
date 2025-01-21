using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChestView : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    private ChestScriptableObject chestSO;

    [SerializeField] private TextMeshProUGUI chestStateText;
    [SerializeField] private Image chestImage;
    private ChestType chestType;
    private RangeInt coinRange;
    private RangeInt gemRange;
    private int unlockTime;     //timer in seconds

    private ChestController chestController;

    private Coroutine timerCoroutine;
    private int hours, minutes, seconds, totalSeconds;

    public void InitializeChestData(ChestController chestController, ChestScriptableObject chestSO)
    {
        this.chestController = chestController;
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
        chestController.OnMouseHover(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        chestController.OnMouseClick(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        chestController.OnMouseLeave();
    }

    public ChestScriptableObject GetChestData() => chestSO;

    public void StartTimer()
    {
        if(timerCoroutine != null)
            StopCoroutine(timerCoroutine);

        timerCoroutine = StartCoroutine(TimerCoroutine(unlockTime));
    }

    private IEnumerator TimerCoroutine(int durationInMinutes)
    {
        float remainingTime = durationInMinutes * 60;

        while (remainingTime > 0)
        {
            UpdateTimerUI(remainingTime);
            remainingTime -= Time.deltaTime;
            yield return null;
        }

        chestStateText.text = "Collect";
        ChangeState(ChestStates.Unlocked);
    }

    private void UpdateTimerUI(float remainingTime)
    {
        totalSeconds = Mathf.CeilToInt(remainingTime);
        hours = totalSeconds / 3600;
        minutes = (totalSeconds % 3600) / 60;
        seconds = totalSeconds % 60;

        chestStateText.text = $"{hours}:{minutes}:{seconds}";
    }

    public void ChangeState(ChestStates newState) => chestController.ChangeState(newState);
}