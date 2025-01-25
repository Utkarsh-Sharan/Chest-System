using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChestItem : MonoBehaviour, IPointerClickHandler
{
    private int chestID;//related to slot.
    [SerializeField] private ChestView chestView;
    [SerializeField] private TextMeshProUGUI chestStateText;
    private ChestStateMachine stateMachine;
    private ChestController chestController;
    private Coroutine timerCoroutine;

    private void Start()
    {
        chestView = GetComponent<ChestView>();
        chestView.SetChestStateText("Locked");

        stateMachine = new ChestStateMachine();
        stateMachine.ChangeState(ChestStates.Locked);
    }

    public void SetController(ChestController chestController)
    {
        this.chestController = chestController;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        stateMachine.OnClick(this);
    }

    public void StartTimer()
    {
        if (chestController.IsAnotherChestUnlocking())
        {
            //show cannot start timer popup
            Debug.Log("Another chest unlocking!");
            return;
        }

        chestController.SetUnlockingChest(chestView);
        this.ChangeState(ChestStates.Unlocking);

        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);

        timerCoroutine = StartCoroutine(TimerCoroutine(GetChestData().UnlockTime));
    }

    private IEnumerator TimerCoroutine(int durationInMinutes)
    {
        float remainingTime = durationInMinutes * 60;

        while (remainingTime > 0)
        {
            if (GetChestState() == ChestStates.Unlocked) break;

            chestView.UpdateTimerUI(remainingTime);
            remainingTime -= Time.deltaTime;
            yield return null;
        }

        chestController.ClearUnlockingChest();
        chestView.SetChestStateText("Collect");
        ChangeState(ChestStates.Unlocked);
    }

    public void ChangeState(ChestStates newState) => stateMachine.ChangeState(newState);

    public ChestStates GetChestState() => stateMachine.GetCurrentState();

    public void SetChestStateText(string text) => chestStateText.text = text;

    public ChestScriptableObject GetChestData() => chestView.GetChestData();

    public int GetCurrentTime() => chestView.GetCurrentTime();

    public int GetID() => chestID;

    public void SetID(int chestID) => this.chestID = chestID;

    public void Destroy() => Destroy(this.gameObject);
}
