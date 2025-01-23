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
    private int unlockTime;     //timer in minutes

    private ChestController chestController;
    private ChestStateMachine stateMachine;

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

        stateMachine = new ChestStateMachine();
        stateMachine.ChangeState(ChestStates.Locked);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        chestController.OnMouseHover(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        stateMachine.OnClick(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        chestController.OnMouseLeave();
    }

    public ChestScriptableObject GetChestData() => chestSO;

    public void StartTimer()
    {
        if (chestController.IsAnotherChestUnlocking())
        {
            //show cannot start timer popup
            Debug.Log("Another chest unlocking!");
            return;
        }

        chestController.SetUnlockingChest(this);
        this.ChangeState(ChestStates.Unlocking);

        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);

        timerCoroutine = StartCoroutine(TimerCoroutine(unlockTime));
    }

    private IEnumerator TimerCoroutine(int durationInMinutes)
    {
        float remainingTime = durationInMinutes * 60;

        while (remainingTime > 0)
        {
            if (GetChestState() == ChestStates.Unlocked) break;

            UpdateTimerUI(remainingTime);
            remainingTime -= Time.deltaTime;
            yield return null;
        }

        chestController.ClearUnlockingChest();
        chestStateText.text = "Collect";
        ChangeState(ChestStates.Unlocked);
    }

    private void UpdateTimerUI(float remainingTime)
    {
        totalSeconds = Mathf.CeilToInt(remainingTime);
        hours = totalSeconds / 3600;
        minutes = (totalSeconds % 3600) / 60;
        seconds = totalSeconds % 60;

        chestStateText.text = $"{hours:00}:{minutes:00}:{seconds:00}";
    }

    public int GetCurrentTime() => (hours * 60 + minutes);

    public void ChangeState(ChestStates newState) => stateMachine.ChangeState(newState);

    public ChestStates GetChestState() => stateMachine.GetCurrentState();

    public void SetChestStateText(string text) => chestStateText.text = text;

    public void Destroy() => Destroy(this.gameObject);
}