using UnityEngine;

public class SlotService
{
    private SlotController slotController;

    public SlotService(SlotController slotController)
    {
        this.slotController = slotController;
    }

    public bool IsEmptySlotAvailable() => slotController.IsEmptySlotAvailable();

    public int AddChestToSlot(ChestView chestObject) => slotController.AddChestToSlot(chestObject);

    public void RemoveChestFromSlot(int index) => slotController.RemoveChestFromSlot(index);
}
