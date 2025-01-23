public class CollectedState : IChestState
{
    public void OnStateEnter()
    {
        
    }

    public void OnClick(ChestView chestView)
    {
        GameService.Instance.CurrencyService.ChestCollected(chestView);
        GameService.Instance.SlotService.RemoveChestFromSlot(chestView);
        GameService.Instance.UIService.CloseHoverPopup();
        chestView.Destroy();
    }

    public void OnStateExit()
    {
        
    }
}
