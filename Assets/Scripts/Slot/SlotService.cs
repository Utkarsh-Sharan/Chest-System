using UnityEngine;

public class SlotService
{
    private SlotController slotController;

    public SlotService(SlotController slotController)
    {
        this.slotController = slotController;
    }

    public int GetFirstAvailableEmptySlot() => slotController.GetFirstAvailableEmptySlot();

    public Transform GetSlotTransform(int index) => slotController.GetSlotTransform(index);

    public void UpdateSlotState(int index, SlotState state) => slotController.UpdateSlotState(index, state);
}
