using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChestController : MonoBehaviour
{
    [SerializeField] private ChestView chestView;
    private IChestState currentState;

    public void Init()
    {
        SetChestState(new LockedState());
    }

    public void SetChestState(IChestState newState)
    {
        currentState?.OnStateExit();
        currentState = newState;
        currentState.OnStateEnter();
    }

    public void CreateRandomChest(List<ChestScriptableObject> chestSO)
    {
        bool isEmptySlotAvailable = GameService.Instance.SlotService.IsEmptySlotAvailable();
        if (!isEmptySlotAvailable)
            return;

        ChestScriptableObject randomChestSO = chestSO[Random.Range(0, chestSO.Count)];

        chestView.SetController(this);
        chestView.InitializeChestData(randomChestSO);
        GameService.Instance.SlotService.AddChestToSlot(chestView);
    }

    public void OnMouseHover(ChestView chestView)
    {
        //display popup showing chest stats(coin and gem count).
        GameService.Instance.UIService.OpenPopupOfType(PopupType.Chest_Hover_Popup, chestView);
    }

    public void OnMouseClick(ChestView chestView)
    {
        //close popup showing chest stats.

        //decided on the basis of STATE in which the chest is. If the chest is-
        //LOCKED    - then on click, popup to show Start Timer and Unlock with gems button.
        //UNLOCKING - then on click, popup to show Unlock with gems button only.
        //UNLOCKED  - then on click, change chest's state to COLLECTED.
        //COLLECTED - simply destroy This chest and change slot's state to EMPTY.
        currentState.OnClick(chestView);
    }

    public void OnMouseLeave(ChestView chestView)
    {
        //close popup showing chest stats.
        GameService.Instance.UIService.CloseAllPopups();
    }
}
