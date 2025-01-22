using UnityEngine;

public class SlotService
{
    private SlotController slotController;

    public SlotService(SlotController slotController)
    {
        this.slotController = slotController;
    }

    public bool IsEmptySlotAvailable() => slotController.IsEmptySlotAvailable();

    public void AddChestToSlot(ChestView chestObject) => slotController.AddChestToSlot(chestObject);
}
