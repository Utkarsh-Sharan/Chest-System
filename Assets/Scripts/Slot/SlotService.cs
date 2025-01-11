public class SlotService
{
    private SlotController slotController;

    public SlotService()
    {
        slotController = new SlotController();
    }

    public void SetSlotState(SlotState slotState) => slotController.SetSlotState(slotState);

    public SlotState GetSlotState() => slotController.GetSlotState();
}
