public class UnlockedState : IChestState
{
    public void OnStateEnter()
    {
        
    }

    public void OnClick(ChestItem chestItem)
    {
        ChestView chestView = chestItem.GetComponent<ChestView>();
        GameService.Instance.CurrencyService.ChestCollected(chestView);  //only pass data, not the whole view.
        GameService.Instance.SlotService.RemoveChestFromSlot(chestView);
        GameService.Instance.UIService.CloseHoverPopup();
        chestView.Destroy();
    }

    public void OnStateExit()
    {
        
    }
}
