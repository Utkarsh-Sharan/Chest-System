using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChestView : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    private ChestScriptableObject chestSO;

    [SerializeField] private TextMeshProUGUI chestStateText;//x
    [SerializeField] private Image chestImage;
    private ChestType chestType;
    private RangeInt coinRange;
    private RangeInt gemRange;
    private int unlockTime;     //timer in minutes

    private ChestController chestController;
    private ChestStateMachine stateMachine;//x

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

        chestStateText.text = "Locked";//x

        stateMachine = new ChestStateMachine();//x
        stateMachine.ChangeState(ChestStates.Locked);//x
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameService.Instance.UIService.OpenPopup(PopupType.Chest_Hover_Popup, this);
    }

    public void OnPointerClick(PointerEventData eventData)//x
    {
        //stateMachine.OnClick(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameService.Instance.UIService.CloseHoverPopup();
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
        this.ChangeState(ChestStates.Unlocking);//x

        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);

        timerCoroutine = StartCoroutine(TimerCoroutine(unlockTime));
    }

    private IEnumerator TimerCoroutine(int durationInMinutes)
    {
        float remainingTime = durationInMinutes * 60;

        while (remainingTime > 0)
        {
            if (GetChestState() == ChestStates.Unlocked) break;//x

            UpdateTimerUI(remainingTime);
            remainingTime -= Time.deltaTime;
            yield return null;
        }

        chestController.ClearUnlockingChest();
        chestStateText.text = "Collect";//x
        ChangeState(ChestStates.Unlocked);//x
    }

    private void UpdateTimerUI(float remainingTime)
    {
        totalSeconds = Mathf.CeilToInt(remainingTime);
        hours = totalSeconds / 3600;
        minutes = (totalSeconds % 3600) / 60;
        seconds = totalSeconds % 60;

        chestStateText.text = $"{hours:00}:{minutes:00}:{seconds:00}";//x
    }

    public int GetCurrentTime() => (hours * 60 + minutes);

    public void ChangeState(ChestStates newState) => stateMachine.ChangeState(newState);//x

    public ChestStates GetChestState() => stateMachine.GetCurrentState();//x

    public void SetChestStateText(string text) => chestStateText.text = text;

    public void Destroy() => Destroy(this.gameObject);
}