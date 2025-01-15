using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChestController : MonoBehaviour
{
    [SerializeField] private ChestView chestView;
    private List<ChestScriptableObject> chestSO;
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
        this.chestSO = chestSO;

        int firstEmptySlotIndex = GameService.Instance.SlotService.GetFirstAvailableEmptySlot();
        if (firstEmptySlotIndex == -1)
        {
            Debug.Log("No available slots to create a chest.");
            return;
        }

        ChestScriptableObject randomChestSO = chestSO[Random.Range(0, chestSO.Count)];

        Transform slotTransform = GameService.Instance.SlotService.GetSlotTransform(firstEmptySlotIndex);

        GameObject chestObject = Instantiate(chestView.gameObject, slotTransform.position, Quaternion.identity, slotTransform);
        ChestView chestViewComponent = chestObject.GetComponent<ChestView>();
        chestViewComponent.InitializeChestData(randomChestSO);
        chestViewComponent.SetController(this);

        GameService.Instance.SlotService.UpdateSlotState(firstEmptySlotIndex, SlotState.Occupied);
    }

    public void OnMouseHover(ChestView chestView)
    {
        //display popup showing chest stats(coin and gem count).
        GameService.Instance.UIService.ShowChestDataOnHover(chestView);
    }

    public void OnMouseClick(ChestView chestView)
    {
        //close popup showing chest stats.

        //decided on the basis of STATE in which the chest is. If the chest is-
        //LOCKED    - then on click, popup to show Start Timer and Unlock with gems button.
        //UNLOCKING - then on click, popup to show Unlock with gems button only.
        //UNLOCKED  - then on click, change chest's state to COLLECTED.
        //COLLECTED - simply destroy This chest and change slot's state to EMPTY.
        currentState.OnClick();
    }

    public void OnMouseLeave(ChestView chestView)
    {
        //close popup showing chest stats.
        GameService.Instance.UIService.ClosePopupPanel();
    }
}
